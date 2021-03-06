using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Brevitee;
using Brevitee.Encryption;
using Brevitee.Configuration;
using Brevitee.ServiceProxy;
using Brevitee.Logging;
using Brevitee.Web;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System.IO;

namespace Brevitee.ServiceProxy.Secure
{
    /// <summary>
    /// A secure service proxy client that uses application level encryption
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SecureServiceProxyClient<T>: ServiceProxyClient<T>
    {
        public SecureServiceProxyClient(string baseAddress)
            : base(baseAddress)
        {
            this.Initialize();
        }
        
        public SecureServiceProxyClient(string baseAddress, string implementingClassName)
            : base(baseAddress, implementingClassName)
        {
            this.Initialize();
        }

        private void Initialize()
        {            
            this.InvokingMethod += (s, a) =>
            {
                TryStartSession();
            };

            //this.Posting += (s, a) =>
            //{
            //    if(RequiresApiKey)
            //    {
            //        string className = a.ClassName;
            //        string methodName = a.MethodName;
            //        string stringToHash = ApiParameters.GetStringToHash(className, methodName, a.PostParameters);

            //        ApiKeyResolver.SetToken(a.Request, stringToHash);
            //    }
            //};
        }

        private void TryStartSession()
        {
            try
            {
                StartSession();
            }
            catch (Exception ex)
            {
                SessionStartException = ex;
            }
        }

        ApiKeyResolver _apiKeyResolver;
        object _apiKeyResolverSync = new object();
        public ApiKeyResolver ApiKeyResolver
        {
            get
            {
                return _apiKeyResolverSync.DoubleCheckLock(ref _apiKeyResolver, () => new ApiKeyResolver());
            }
            set
            {
                _apiKeyResolver = value;
            }
        }

        public Exception SessionStartException
        {
            get;
            private set;
        }

        public bool SessionEstablished
        {
            get
            {
                return SessionInfo != null && SessionInfo.SessionId > 0 && !string.IsNullOrEmpty(SessionInfo.PublicKey);
            }            
        }

        public Cookie SessionCookie
        {
            get;
            protected set;
        }

        ClientSessionInfo _sessionInfo;
        protected internal ClientSessionInfo SessionInfo
        {
            get
            {
                return _sessionInfo;
            }
            internal set
            {
                _sessionInfo = value;
            }
        }

        protected bool RequiresApiKey
        {
            get
            {
                return typeof(T).HasCustomAttributeOfType<ApiKeyRequiredAttribute>();
            }
        }

        /// <summary>
        /// The key for the current session.
        /// </summary>
        protected string SessionKey
        {
            get;
            set;
        }

        /// <summary>
        /// The initialization vector for the current session
        /// </summary>
        protected string SessionIV
        {
            get;
            set;
        }

        public event Action<SecureServiceProxyClient<T>> SessionStarting;
        protected void OnSessionStarting()
        {
            if (SessionStarting != null)
            {
                SessionStarting(this);
            }
        }

        public event Action<SecureServiceProxyClient<T>> SessionStarted;
        protected void OnSessionStarted()
        {
            if (SessionStarted != null)
            {
                SessionStarted(this);
            }
        }

        /// <summary>
        /// The event that is raised if an exception occurs starting the 
        /// secure session.
        /// </summary>
        public event Action<SecureServiceProxyClient<T>, Exception> StartSessionException;
        protected void OnStartSessionException(Exception ex)
        {
            if (StartSessionException != null)
            {
                StartSessionException(this, ex);
            }
        }

        object _sessionInfoLock = new object();
        public void StartSession()
        {
            if (SessionInfo == null)
            {
                lock (_sessionInfoLock)
                {
                    if (SessionInfo == null)
                    {
                        OnSessionStarting();

                        try
                        {
                            // client.startSession->server
                            //SecureChannelMessage<SessionInfo> response = this.Get<SecureChannelMessage<SessionInfo>>(typeof(SecureChannelServer).Name, "StartSession", new object[] { });
                            //"{BaseAddress}{Verb}/{ClassName}/{MethodName}.json?{Parameters}";
                            HttpWebRequest request = GetServiceProxyRequest<SecureChannel>(ServiceProxyVerbs.GET, "InitSession", new Instant());

                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            {
                                SessionCookie = response.Cookies[ServiceProxySystem.SecureSessionName];
                                Cookies.Add(SessionCookie);

                                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                                {
                                    SecureChannelMessage<ClientSessionInfo> message = sr.ReadToEnd().FromJson<SecureChannelMessage<ClientSessionInfo>>();
                                    if (!message.Success)
                                    {
                                        throw new Exception(message.Message);
                                    }
                                    else
                                    {
                                        SessionInfo = message.Data;
                                    }
                                }

                                SetSessionKeyAndIv();
                            }
                        }
                        catch (Exception ex)
                        {
                            SessionStartException = ex;
                            OnStartSessionException(ex);
                            return;
                        }

                        OnSessionStarted();
                    }
                }

            }
        }

        /// <summary>
        /// The event that will occur if an exception occurs during
        /// method invocation
        /// </summary>
        public event Action<SecureServiceProxyClient<T>, Exception> InvocationException;
        protected void OnInvocationException(Exception ex)
        {
            if (InvocationException != null)
            {
                InvocationException(this, ex);
            }
        }

        protected internal override string DoInvoke(string baseAddress, string className, string methodName, object[] parameters)
        {
            try
            {                   
                SecureChannelMessage<string> result = Post(baseAddress, typeof(SecureChannel).Name, "Invoke", new object[] { className, methodName, ApiParameters.ParametersToJsonParamsObject(parameters) }).FromJson<SecureChannelMessage<string>>();
                if (result.Success)
                {
                    Decrypted decrypted = new Decrypted(result.Data, SessionKey, SessionIV);
                    return decrypted.Value;
                }
                else
                {
                    string properties = result.Data.PropertiesToString();                    
                    throw new ServiceProxyInvocationFailedException("{0}:\r\n{1}"._Format(result.Message, properties));
                }
            }
            catch (Exception ex)
            {
                OnInvocationException(ex);
            }

            return string.Empty;
        }

        protected override string Post(string baseAddress, string className, string methodName, object[] parameters, HttpWebRequest request)
        {
            if (className.ToLowerInvariant().Equals("securechannel") && methodName.ToLowerInvariant().Equals("invoke"))
            {
                // the target is the SecureChannel.Invoke method but we
                // need the actual className and method that is in the parameters 
                // object
                string actualClassName = (string)parameters[0];
                string actualMethodName = (string)parameters[1];                
                string jsonParams = (string)parameters[2];
                HttpArgs args = new HttpArgs();
                args.ParseJson(jsonParams);

                ApiKeyResolver.SetToken(request, ApiParameters.GetStringToHash(actualClassName, actualMethodName, args["jsonParams"]));
            }
            return base.Post(baseAddress, className, methodName, parameters, request);
        }

        protected internal override void WriteJsonParams(string jsonParamsString, HttpWebRequest request)
        {
            if (string.IsNullOrEmpty(SessionKey))
            {
                base.WriteJsonParams(jsonParamsString, request);
            }
            else
            {
                Encrypted cipher = new Encrypted(jsonParamsString, SessionKey, SessionIV);
                string postData = cipher.Base64Cipher;
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(postData);
                }

                ApiValidation.SetValidationToken(request, jsonParamsString, SessionInfo.PublicKey);

                request.ContentType = "text/plain; charset=utf-8";
            }
        }

        protected internal ValidationToken CreateValidationToken(string jsonParamsString)
        {
            string publicKeyPem = SessionInfo.PublicKey;

            return CreateValidationToken(jsonParamsString, publicKeyPem);
        }

        private static ValidationToken CreateValidationToken(string jsonParamsString, string publicKeyPem)
        {
            return ApiValidation.CreateValidationToken(jsonParamsString, publicKeyPem);
        }
        
        protected internal override HttpWebRequest GetServiceProxyRequest(ServiceProxyVerbs verb, string className, string methodName, string queryStringParameters = "")
        {
            HttpWebRequest request = base.GetServiceProxyRequest(verb, className, methodName, queryStringParameters);           

            if (SessionCookie == null)
            {
                Logger.AddEntry("Session Cookie ({0}) was missing, call StartSession() first", LogEventType.Warning, ServiceProxySystem.SecureSessionName);
            }
            else
            {
                request.Headers.Add(ServiceProxySystem.SecureSessionName, SessionCookie.Value);
            }
            return request;
        }

        protected internal void SetSessionKeyAndIv()
        {
            AesKeyVectorPair kvp;
            SetSessionKeyRequest request;
            CreateSetSessionKeyRequest(out kvp, out request);

            SecureChannelMessage response = this.Post<SecureChannelMessage>(typeof(SecureChannel).Name, "SetSessionKey", new object[] { request });
            if (!response.Success)
            {
                throw new Exception(response.Message);
            }

            SessionKey = kvp.Key;
            SessionIV = kvp.IV;
        }

        protected internal void CreateSetSessionKeyRequest(out AesKeyVectorPair kvp, out SetSessionKeyRequest request)
        {
            kvp = new AesKeyVectorPair();
            string keyCipher = kvp.Key.EncryptWithPublicKey(SessionInfo.PublicKey, Encoding.UTF8);
            string keyHash = kvp.Key.Sha1();
            string keyHashCipher = keyHash.EncryptWithPublicKey(SessionInfo.PublicKey, Encoding.UTF8);
            string ivCipher = kvp.IV.EncryptWithPublicKey(SessionInfo.PublicKey, Encoding.UTF8);
            string ivHash = kvp.IV.Sha1();
            string ivHashCipher = ivHash.EncryptWithPublicKey(SessionInfo.PublicKey, Encoding.UTF8);

            request = new SetSessionKeyRequest(keyCipher, keyHashCipher, ivCipher, ivHashCipher);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using Brevitee.Html;
using Brevitee.Logging;
using Brevitee;
using Brevitee.Incubation;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Brevitee.Data;
using Brevitee.Configuration;
using Brevitee.ServiceProxy;
using Brevitee.Web;
using System.IO;
using Brevitee.UserAccounts;
using Brevitee.Management;

namespace Brevitee.Server
{
    public class BreviteeServer: IInitialize<BreviteeServer>
    {
		HashSet<IResponder> _responders;
        HttpServer _server;
		const string ServerWorkspace = "serverWorkspace";
        
        #region configurable ctors
        public BreviteeServer(BreviteeConf conf)
        {
			this._responders = new HashSet<IResponder>();
            this.Initialized += HandleInitialization;
            this.SetConf(conf);
			this.EnableDao = true;
			this.EnableServiceProxy = true;

            SQLiteRegistrar.RegisterFallback();

            AppDomain.CurrentDomain.DomainUnload += (s, a) =>
            {
                this.Stop();
            };
        }

        TemplateInitializerBase _templateInitializer;
        object _templateInitializerLock = new object();
        // The initializer used to initialize templates 
        // after full server initialization
        public TemplateInitializerBase TemplateInitializer
        {
            get
            {
                return _templateInitializerLock.DoubleCheckLock(ref _templateInitializer, () => new DustTemplateInitializer(this));
            }
            set
            {
                _templateInitializer = value;
            }
        }
        
        #endregion

        public bool IsInitialized
        {
            get;
            private set;
        }

        public SchemaInitializer[] SchemaInitializers // gets set by CopyProperties in SetConf
        {
            get;
            set;
        }

        public event Action<BreviteeServer> Initializing;
        public event Action<BreviteeServer> Initialized;

        protected void OnInitializing()
        {
            if (Initializing != null)
            {
                Initializing(this);
            }
        }

        protected void OnInitialized()
        {
            if (Initialized != null)
            {
                Initialized(this);
            }
        }

        public event Action<BreviteeServer> SchemasInitializing;
        public event Action<BreviteeServer> SchemasInitialized;

        protected void OnSchemasInitializing()
        {
            if (SchemasInitializing != null)
            {
                SchemasInitializing(this);
            }
        }

        protected void OnSchemasInitialized()
        {
            if (SchemasInitialized != null)
            {
                SchemasInitialized(this);
            }
        }

        public event Action<BreviteeServer, SchemaInitializer> SchemaInitializing;
        public event Action<BreviteeServer, SchemaInitializer> SchemaInitialized;

        protected void OnSchemaInitializing(SchemaInitializer initializer)
        {
            if (SchemaInitializing != null)
            {
                SchemaInitializing(this, initializer);
            }
        }
        protected void OnSchemaInitialized(SchemaInitializer initializer)
        {
            if (SchemaInitialized != null)
            {
                SchemaInitialized(this, initializer);
            }
        }

        public virtual void Initialize()
        {
            if (!this.IsInitialized)
            {
                OnInitializing();
                LoadConf();

                Subscribe(Logger);
                SubscribeResponders(Logger);

                EnsureDefaults();
                Logger.AddEntry("{0} initializing: \r\n{1}", this.GetType().Name, this.PropertiesToString());
                
                InitializeCommonSchemas();

                InitializeResponders();

                InitializeUserManagers();
				
				ConfigureHttpServer();

                OnInitialized();
            }
            else
            {
                Logger.AddEntry("Initialize called but the {0} was already initialized", LogEventType.Warning, this.GetType().Name);
            }
        }

        /// <summary>
        /// Initialize server level schemas
        /// </summary>
        protected virtual void InitializeCommonSchemas()
        {
            OnSchemasInitializing();
            SchemaInitializers.Each(schemaInitializer =>
            {
                OnSchemaInitializing(schemaInitializer);
                Exception ex;
                if (!schemaInitializer.Initialize(Logger, out ex))
                {
                    Logger.AddEntry("An error occurred initializing schema ({0}): {1}", ex, schemaInitializer.SchemaName, ex.Message);
                }
                OnSchemaInitialized(schemaInitializer);
            });
            OnSchemasInitialized();
        }

        protected virtual void InitializeUserManagers()
        {
            ContentResponder.AppConfigs.Each(appConfig =>
            {
                try
                {
                    UserManager mgr = appConfig.UserManager.Create(Logger);
					// TODO: Use service locator (incubator) here
                    mgr.ApplicationNameResolver = new AppConfApplicationNameProvider(appConfig);
                    AddAppService<UserManager>(appConfig.Name, mgr);
                }
                catch (Exception ex)
                {
                    Logger.AddEntry("An error occurred initializing user manager for app ({0}): {1}", ex, appConfig.Name, ex.Message);
                }
            });
        }

        protected virtual void InitializeResponders()
        {
			foreach(IResponder responder in _responders)
			{
				responder.Subscribe(Logger);
				responder.Initialize();
			}
        }
        
		/// <summary>
		/// Subscribe the specified logger to the events of the
		/// ContentResponder.  Will also subscribe to the DaoResponder
		/// if EnableDao is true and the ServiceProxyReponder if
		/// EnableServiceProxy is true.  Additionally, will subscribe to
		/// any other responders that have been added using AddResponder
		/// </summary>
		/// <param name="logger"></param>
        protected virtual void SubscribeResponders(ILogger logger)
        {
			foreach (IResponder responder in _responders)
			{
				responder.Subscribe(logger);
			}
        }

        List<ILogger> _subscribers = new List<ILogger>();
        object _subscriberLock = new object();
        public ILogger[] Subscribers
        {
            get
            {
                if (_subscribers == null)
                {
                    _subscribers = new List<ILogger>();
                }
                lock (_subscriberLock)
                {
                    return _subscribers.ToArray();
                }
            }
        }

        public bool IsSubscribed(ILogger logger)
        {
            lock (_subscriberLock)
            {
                return _subscribers.Contains(logger);
            }
        }

		/// <summary>
		/// Subscribe the specified logger to the 
		/// events of the current BreviteeServer
		/// </summary>
		/// <param name="logger"></param>
        public void Subscribe(ILogger logger)
        {
            if (!IsSubscribed(logger))
            {
                lock (_subscriberLock)
                {
                    _subscribers.Add(logger);
                }
                string className = typeof(BreviteeServer).Name;
                this.Initializing += (s) =>
                {
                    logger.AddEntry("{0}::Initializ(ING)", className);
                };
                this.Initialized += (s) =>
                {
                    logger.AddEntry("{0}::Initializ(ED)", className);
                };
                this.LoadingConf += (s, c) =>
                {
                    logger.AddEntry("{0}::Load(ING) configuration, current config: \r\n{1}", className, c.PropertiesToString());
                };
                this.LoadedConf += (s, c) =>
                {
                    logger.AddEntry("{0}::Load(ED) configuration, current config: \r\n{1}", className, c.PropertiesToString());
                };
                this.SettingConf += (s, c) =>
                {
                    logger.AddEntry("{0}::Sett(ING) configuration, current config: \r\n{1}", className, c.PropertiesToString());
                };
                this.SettedConf += (s, c) =>
                {
                    logger.AddEntry("{0}::Sett(ED) configuration, current config: \r\n{1}", className, c.PropertiesToString());
                };
                this.SchemasInitializing += (s) =>
                {
                    logger.AddEntry("{0}::Initializ(ING) schemas", className);
                };
                this.SchemasInitialized += (s) =>
                {
                    logger.AddEntry("{0}::Initializ(ED) schemas", className);
                };
                this.Starting += (s) =>
                {
                    logger.AddEntry("{0}::Start(ING)", className);
                };

                this.Started += (s) =>
                {
                    logger.AddEntry("{0}::Start(ED)", className);
                };

                this.Stopping += (s) =>
                {
                    logger.AddEntry("{0}::stopping", className);
                };

                this.Stopped += (s) =>
                {
                    logger.AddEntry("{0}::stopped", className);
                };
            }
        }

        ILogger _logger;
        object _loggerLock = new object();
        public ILogger Logger
        {
            get
            {
                return _loggerLock.DoubleCheckLock(ref _logger, () =>
                {
                    Log.Start();
                    return Log.Default;
                });
            }
            set
            {
                if (_logger != null)
                {
                    _logger.StopLoggingThread();
                }

                _logger = value;
                _logger.RestartLoggingThread();
                if (IsRunning)
                {
                    Restart();
                }
            }
        }

        public HostPrefix[] GetHostPrefixes()
        {
            BreviteeConf serverConfig = GetCurrentConf(false);
            List<HostPrefix> results = new List<HostPrefix>();
            serverConfig.AppConfigs.Each(appConf =>
            {
                results.AddRange(appConf.Bindings);
            });

            return results.ToArray();
        }

        public ProxyAlias[] ProxyAliases
        {
            get;
            set;
        }

        public bool GenerateDao
        {
            get;
            set;
        }

        public bool InitializeTemplates
        {
            get;
            set;
        }

        int _maxThreads;
        public int MaxThreads
        {
            get
            {
                return _maxThreads;
            }
            set
            {
                _maxThreads = value;
            }
        }
        
        string _contentRoot;
        public string ContentRoot
        {
            get
            {
                return _contentRoot;
            }
            set
            {
                _contentRoot = new Fs(value).Root;
				ContentResponder.BreviteeConf = GetCurrentConf();
            }
        }
        
        public event Action<BreviteeServer, BreviteeConf> LoadingConf;
        public event Action<BreviteeServer, BreviteeConf> LoadedConf;

        protected void OnLoadingConf()
        {
            if (LoadingConf != null)
            {
                LoadingConf(this, GetCurrentConf());
            }
        }

        protected void OnLoadedConf(BreviteeConf conf)
        {
            if (LoadedConf != null)
            {
                LoadedConf(this, conf);
            }
        }

        /// <summary>
        /// Loads the server configuration from either a json file, yaml file
        /// or the default config depending on which is found first in that 
        /// order.
        /// </summary>
        public BreviteeConf LoadConf()
        {
            OnLoadingConf();
            BreviteeConf conf = BreviteeConf.Load(ContentRoot);
            SetConf(conf);
            OnLoadedConf(conf);
            return conf;
        }

        public event Action<BreviteeServer, AppConf> CreatingApp;
        public event Action<BreviteeServer, AppConf> CreatedApp;

        protected void OnCreatingApp(AppConf conf)
        {
            if (CreatingApp != null)
            {
                CreatingApp(this, conf);
            }
        }

        protected void OnCreatedApp(AppConf conf)
        {
            if (CreatedApp != null)
            {
                CreatedApp(this, conf);
            }
        }

		public AppContentResponder CreateApp(string appName, string defaultLayout = null)
        {
            AppConf conf = new AppConf(appName);
            if (!string.IsNullOrEmpty(defaultLayout))
            {
                conf.DefaultLayout = defaultLayout;
            }
            OnCreatingApp(conf);

            AppContentResponder responder = new AppContentResponder(ContentResponder, conf);
            responder.Initialize();

            OnCreatedApp(conf);
			return responder;
        }

        public event Action<BreviteeServer, BreviteeConf> SettingConf;
        public event Action<BreviteeServer, BreviteeConf> SettedConf;

        protected void OnSettingConf(BreviteeConf conf)
        {
            if (SettingConf != null)
            {
                SettingConf(this, conf);
            }
        }

        protected void OnSettedConf(BreviteeConf conf)
        {
            if (SettedConf != null)
            {
                SettedConf(this, conf);
            }
        }

        public void SetConf(BreviteeConf conf)
        {
            OnSettingConf(conf);
            DefaultConfiguration.CopyProperties(conf, this);
            Type loggerType;
            this.Logger = Log.Default = conf.GetLogger(out loggerType);
			this.Logger.RestartLoggingThread();
            if (!loggerType.Name.Equals(conf.LoggerName))
            {
                Logger.AddEntry("Configured Logger was ({0}) but the Logger found was ({1})", LogEventType.Warning, conf.LoggerName, loggerType.Name);
            }

            conf.Server = this;

            OnSettedConf(conf);
        }

        public event Action<BreviteeServer, BreviteeConf> SavedConf;
        
        protected void OnSavedConf(BreviteeConf conf)
        {
            if (SavedConf != null)
            {
                SavedConf(this, conf);
            }
        }

        /// <summary>
        /// Saves the current configuration if the config 
        /// file doesn't currently exist
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public BreviteeConf SaveConf(bool overwrite = false, ConfFormat format = ConfFormat.Json)
        {
            BreviteeConf conf = GetCurrentConf();
            conf.Save(ContentRoot, overwrite, format);
            OnSavedConf(conf);
            return conf;
        }

		ContentResponder _contentResponder;
        public ContentResponder ContentResponder
        {
            get
            {
				if (_contentResponder == null)
				{
					SetContentResponder();
				}
				return _contentResponder;
            }
        }


		DaoResponder _daoResponder;
        public DaoResponder DaoResponder
        {
            get
            {
				if (_daoResponder == null)
				{
					SetDaoResponder();
				}
				return _daoResponder;
            }
        }

		ServiceProxyResponder _serviceProxyResponder;
        public ServiceProxyResponder ServiceProxyResponder
        {
            get
            {
				if (_serviceProxyResponder == null)
				{
					SetServiceProxyResponder();
				}
				return _serviceProxyResponder;
            }
        }

        public void SubscribeToResponded<T>(ResponderEventHandler subscriber) where T : class, IResponder
        {
            Responders.Each(r =>
            {
                T responder = r as T;
                if (responder != null)
                {
                    responder.Responded += subscriber;
                }
            });
        }

        public void SubscribeToNotResponded<T>(ResponderEventHandler subscriber) where T : class, IResponder
        {
            Responders.Each(r =>
            {
                T responder = r as T;
                if (responder != null)
                {
                    responder.NotResponded += subscriber;
                }
            });
        }

        public void SubscribeToResponded(ResponderEventHandler subscriber)
        {
            Responders.Each(r =>
            {
                r.Responded += subscriber;
            });
        }

        public void SubscribeToNotResponded(ResponderEventHandler subscriber)
        {
            Responders.Each(r =>
            {
                r.NotResponded += subscriber;
            });
        }

        
        public event Action<BreviteeServer> Starting;
        public event Action<BreviteeServer> Started;

        public event Action<BreviteeServer> Stopping;
        public event Action<BreviteeServer> Stopped;


        public void Start()
        {
			SetWorkspace();
            Initialize();

            OnStarting();
            _server.Start();
            IsRunning = true;
            OnStarted();
        }

        public void Stop()
        {
            if(IsInitialized)
            {
                SaveConf();

                OnStopping();
                _server.Stop();
                IsRunning = false;
                OnStopped();
            }
        }

        public void Restart()
        {
            Stop();
            this.IsInitialized = false;
            Start();
        }
        
        public Incubator CommonServiceProvider
        {
            get
            {
                return ServiceProxyResponder.CommonServiceProvider;
            }
        }

        public Dictionary<string, Incubator> AppServiceProviders
        {
            get
            {
                return ServiceProxyResponder.AppServiceProviders;
            }
        }

		public Dictionary<string, AppContentResponder> AppContentResponders
		{
			get
			{
				return ContentResponder.AppContentResponders;
			}
		}

        public void AddCommonService<T>()
        {
            ServiceProxyResponder.AddCommonService<T>((T)typeof(T).Construct());
        }

        public void AddCommonService<T>(T instance)
        {
            ServiceProxyResponder.AddCommonService<T>(instance);
        }

        public void AddAppService<T>(string appName)
        {
            ServiceProxyResponder.AddAppService<T>(appName, (T)typeof(T).Construct());
        }

        public void AddAppService<T>(string appName, T instance)
        {
            ServiceProxyResponder.AddAppService<T>(appName, instance);
        }

        public void AddAppService<T>(string appName, Func<T> instanciator)
        {
            ServiceProxyResponder.AddAppService<T>(appName, instanciator);
        }

        public void AddAppService<T>(string appName, Func<Type, T> instanciator)
        {
            ServiceProxyResponder.AddAppService<T>(appName, instanciator);
        }

        public void AddLogger(ILogger logger)
        {
            MultiTargetLogger mtl = new MultiTargetLogger();
            if(Logger != null)
            {
                if(Logger.GetType() == typeof(MultiTargetLogger))
                {
                    mtl = (MultiTargetLogger)Logger;
                }
                else
                {
                    mtl.AddLogger(Logger);
                }
            }

            mtl.AddLogger(logger);
            Logger = mtl;
        }

		public event Action<BreviteeServer, IResponder> ResponderAdded;
		/// <summary>
		/// Add an IResponder implementation to this
		/// request handler
		/// </summary>
		/// <param name="responder"></param>
		public void AddResponder(IResponder responder)
		{
			this._responders.Add(responder);
			if (ResponderAdded != null)
			{
				ResponderAdded(this, responder);
			}
		}

		public void RemoveResponder(IResponder responder)
		{
			if (_responders.Contains(responder))
			{
				_responders.Remove(responder);
			}
		}

		public IResponder[] Responders
		{
			get
			{
				return _responders.ToArray();
			}
		}

		Action<IHttpContext> _responderNotFoundHandler;
		object _responderNotFoundHandlerLock = new object();
		/// <summary>
		/// Get or set the default handler used when no appropriate
		/// responder is found for a given request.  This is the 
		/// Action responsible for responding with a 404 status code
		/// and supplying any additional information to the client.
		/// </summary>
		public Action<IHttpContext> ResponderNotFoundHandler
		{
			get
			{
				return _responderNotFoundHandlerLock.DoubleCheckLock(ref _responderNotFoundHandler, () => HandleResponderNotFound);
			}
			set
			{
				_responderNotFoundHandler = value;
			}
		}

		Action<IHttpContext, Exception> _exceptionHandler;
		object _exceptionHandlerLock = new object();
		/// <summary>
		/// Get or set the default exception handler.  This is the
		/// Action responsible for responding with a 500 status code
		/// and supplying any additional information to the client
		/// pertaining to exceptions that may occur on the server.
		/// </summary>
		public Action<IHttpContext, Exception> ExceptionHandler
		{
			get
			{
				return _exceptionHandlerLock.DoubleCheckLock(ref _exceptionHandler, () => HandleException);
			}
			set
			{
				_exceptionHandler = value;
			}
		}
		
		public void HandleRequest(IHttpContext context)
		{
			IRequest request = context.Request;
			IResponse response = context.Response;
			IResponder responder = new ResponderList(_conf, _responders);
			try
			{
				if (!responder.Respond(context))
				{
					ResponderNotFoundHandler(context);
				}
				else
				{
					response.StatusCode = (int)HttpStatusCode.OK;
					response.OutputStream.Flush();
					response.OutputStream.Close();
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler(context, ex);
			}
		}

		BreviteeConf _conf;
		object _confLock = new object();
		/// <summary>
		/// Get a BreviteeConf instance which represents the current
		/// state of the BreviteeServer
		/// </summary>
		/// <returns></returns>
		internal protected BreviteeConf GetCurrentConf(bool reload = true)
		{
			lock (_confLock)
			{
				if (reload || _conf == null)
				{
					BreviteeConf conf = new BreviteeConf();
					DefaultConfiguration.CopyProperties(this, conf);
					conf.Server = this;
					_conf = conf;
				}
			}
			return _conf;
		}

		protected HttpServer HttpServer
		{
			get { return _server; }
		}

		bool _enableDao;
		/// <summary>
		/// If true will cause the initialization of the 
		/// DaoResponder which will process all *.db.js
		/// and *.db.json files.  See http://breviteedocs.wordpress.com/dao/
		/// for information about the expected format 
		/// of a *.db.js file.  The format of *db.json 
		/// would be the json equivalent of the referenced
		/// database object (see link).  See
		/// Brevitee.Data.Schema.DataTypes for valid
		/// data types.
		/// </summary>
		protected bool EnableDao
		{
			get
			{
				return _enableDao;
			}
			set
			{
				_enableDao = value;
				if (_enableDao)
				{
					SetDaoResponder();
				}
				else
				{
					RemoveResponder(_daoResponder);
				}
			}
		}

		bool _enableServiceProxy;
		/// <summary>
		/// If true will cause the initialization of the
		/// ServiceProxyResponder which will register
		/// all classes addorned with the Proxy attribute
		/// as service proxy executors
		/// </summary>
		protected bool EnableServiceProxy
		{
			get
			{
				return _enableServiceProxy;
			}
			set
			{
				_enableServiceProxy = value;
				if (_enableServiceProxy)
				{
					SetServiceProxyResponder();
				}
				else
				{
					RemoveResponder(_serviceProxyResponder);
				}
			}
		}

		protected void SetDaoResponder()
		{
			_daoResponder = new DaoResponder(GetCurrentConf(true), Logger);
			AddResponder(_daoResponder);
		}

		protected void SetServiceProxyResponder()
		{
			_serviceProxyResponder = new ServiceProxyResponder(GetCurrentConf(true), Logger);
			_serviceProxyResponder.ContentResponder = ContentResponder;
			AddResponder(_serviceProxyResponder);
		}

		protected void SetContentResponder()
		{
			_contentResponder = new ContentResponder(GetCurrentConf(true), Logger);
			AddResponder(_contentResponder);
		}

		protected void OnStopping()
		{
			if (Stopping != null)
			{
				Stopping(this);
			}
		}

		protected void OnStopped()
		{
			if (Stopped != null)
			{
				Stopped(this);
			}
		}
		protected void OnStarting()
		{
			if (Starting != null)
			{
				Starting(this);
			}
		}

		protected void OnStarted()
		{
			if (Started != null)
			{
				Started(this);
			}
		}        

		protected internal bool IsRunning
		{
			get;
			private set;
		}
		protected void ProcessRequest(HttpListenerContext context)
		{
			HttpListenerRequest request = context.Request;
			HttpListenerResponse response = context.Response;

			HandleRequest(new HttpContextWrapper(new RequestWrapper(request), new ResponseWrapper(response)));
		}

		private void HandleResponderNotFound(IHttpContext context)
		{
			IResponse response = context.Response;
			IRequest request = context.Request;

			string path = request.Url.ToString();
			string messageFormat = "No responder was found for the path: {0}";
			string description = "Responder not found";

			using (StreamWriter sw = new StreamWriter(response.OutputStream))
			{
				response.StatusCode = (int)HttpStatusCode.NotFound;
				response.StatusDescription = description;
				sw.WriteLine("<!DOCTYPE html>");
				Tag html = new Tag("html");
				html.Child(new Tag("body")
					.Child(new Tag("h1").Text(description))
					.Child(new Tag("p").Text(string.Format(messageFormat, path)))
				);
				sw.WriteLine(html.ToHtmlString());
				sw.Flush();
				sw.Close();
			}

			Logger.AddEntry(messageFormat, LogEventType.Warning, path);
		}

		private void HandleException(IHttpContext context, Exception ex)
		{
			IResponse response = context.Response;
			IRequest request = context.Request;
			using (StreamWriter sw = new StreamWriter(response.OutputStream))
			{
				string description = "({0})"._Format(ex.Message);
				response.StatusCode = (int)HttpStatusCode.InternalServerError;
				response.StatusDescription = description;
				sw.WriteLine("<!DOCTYPE html>");
				Tag html = new Tag("html");
				html.Child(new Tag("body")
					.Child(new Tag("h1").Text("Internal Server Exception"))
					.Child(new Tag("p").Text(description))
				);
				sw.WriteLine(html.ToHtmlString());
				sw.Flush();
				sw.Close();
			}

			Logger.AddEntry("An error occurred handling the request: ({0})\r\n*** Request Details ***\r\n{1}",
					ex,
					ex.Message,
					request.PropertiesToString());
		}
		
		private void HandleInitialization(BreviteeServer server)
		{
			if (server.InitializeTemplates)
			{
				TemplateInitializer.Subscribe(Logger);
				TemplateInitializer.Initialize();
			}

			this.IsInitialized = true;
		}
		
		private void ConfigureHttpServer()
		{
			int maxThreads = this.MaxThreads;
			if (maxThreads < 50)
			{
				maxThreads = 50;
			}

			_server = new HttpServer(maxThreads, Logger);
			_server.HostPrefixes = GetHostPrefixes();
			_server.ProcessRequest += ProcessRequest;
		}

		private void EnsureDefaults()
		{
			if (this.MaxThreads <= 0)
			{
				this.MaxThreads = 50;
				Logger.AddEntry("Set MaxThreads to default value {0}", this.MaxThreads);
			}
		}

		private void SetWorkspace()
		{
			string workSpace = Path.Combine(ContentRoot, ServerWorkspace);
			if (!Directory.Exists(workSpace))
			{
				Directory.CreateDirectory(workSpace);
			}
			Directory.SetCurrentDirectory(workSpace);
		}
    }

}
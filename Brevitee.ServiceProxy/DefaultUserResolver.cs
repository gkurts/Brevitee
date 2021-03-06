using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brevitee.ServiceProxy
{
	/// <summary>
	/// Resolves the current user of the 
	/// application by first trying the default
	/// web user then, if nothing is returned 
	/// returns the owner of the current process.
	/// </summary>
    public class DefaultUserResolver: IUserResolver
    {
        static DefaultUserResolver()
        {
            Instance = new DefaultUserResolver();
        }

        public static IUserResolver Instance
        {
            get;
            set;
        }

        public IHttpContext HttpContext
        {
            get;
            set;
        }

        public string GetCurrentUser()
        {
            string userName = DefaultWebUserResolver.Instance.GetCurrentUser();
            if (string.IsNullOrEmpty(userName))
            {
                userName = UserUtil.GetCurrentWindowsUser(false);
            }

            return userName;
        }

        public string GetUser(IHttpContext context)
        {
            return DefaultWebUserResolver.GetUserFromContext(context);
        }
    }
}

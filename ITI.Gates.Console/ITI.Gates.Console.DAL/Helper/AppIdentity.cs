using ITI.Gates.Console.DAL.Model;
using System.Security.Principal;

namespace ITI.Gates.Console.DAL.Helper
{
    public class AppIdentity : UserLogin, IIdentity
    {
        public string AuthenticationType
        {
            get
            {
                return "Custom";
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return UserId.Length != 0;
            }
        }

        public string Name
        {
            get
            {
                return UserId;
            }
        }
    }
}

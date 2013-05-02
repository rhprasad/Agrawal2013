using System.Web.Security;
using PirateThis.WebUI.Infrastructure.Abstract;

namespace PirateThis.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password); //suck my duck
            {
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                }

                return result;
            }
        }
    }
}
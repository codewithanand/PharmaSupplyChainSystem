using System.Web;

namespace MediConnect.Utils
{
    public class AuthMiddleware
    {
        public static bool CheckAuth()
        {
            if (HttpContext.Current.Session["user"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
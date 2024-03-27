using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MediConnect.Utils
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

    }
    public class Auth
    {
        public static User user = null;

        protected static void setUser(string name, string email, int role)
        {
            user = new User();
            user.Name = name;
            user.Email = email;
            user.Role = role;
        }

        public static User getUser()
        {
            return user;
        }

        public static string getRole()
        {
            switch (user.Role)
            {
                case 0: return "user";
                case 1: return "admin";
                case 2: return "supplier";
                case 3: return "manufacturer";
                case 4: return "wholesaler";
                case 5: return "distributor";
                default: return "user";
            }
        }

        public static void attempt(string name, string email, int role)
        {
            HttpCookie cookie = new HttpCookie("user");
            cookie.Values["name"] = name;
            cookie.Values["email"] = email;
            cookie.Values["role"] = role.ToString();

            cookie.Expires = DateTime.Now.AddDays(2); //Expires in 48 hours
            cookie.SameSite = SameSiteMode.Strict;
            cookie.Secure = true;

            HttpContext.Current.Response.Cookies.Add(cookie);

            setUser(name, email, role);
        }

        public static bool authenticated()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
            if(cookie != null && !string.IsNullOrEmpty(cookie.Values["name"]) && cookie.Expires > DateTime.Now)
            {
                if(user == null) setUser(cookie.Values["name"], cookie.Values["email"], Convert.ToInt16(cookie.Values["role"]));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Logout()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
            if (cookie != null)
            {
                HttpCookie newCookie = new HttpCookie(cookie.Name);
                newCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(newCookie);
                user = null;
            }
        }
    }
}
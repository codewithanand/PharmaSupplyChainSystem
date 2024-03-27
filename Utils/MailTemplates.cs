using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediConnect.Utils
{
    public class MailTemplates
    {
        public static string EmailVerification(string email, string code)
        {
            string body = string.Empty;

            body += "<div style='background-color: #444; color: #fff; font-family: sans-serif; text-align: center; padding:30px 20px;'>";
            body += "<div><span style='color: #3EC1D5;'> Medi </span><span style='color: gold;'> Connect </span></div>";
            body += "<div></div>";
            body += "<div><h1> You're Almost There! </h1></div>";
            body += "<div style='margin-bottom: 30px;'><p style='font-size: 11px;'> Just One More Step To Get Started </p></div>";
            body += "<div><a style='border: none; text-decoration: none; background-color: #fc5c63; color: white; padding: 10px 20px;' href='http://localhost:53990/ActivateAccount.aspx?activation_code=" + code + "&email=" + MyCryptography.Base64Encode(email) + "'> ACTIVATE ACCOUNT </a></div>";
            body += "</div>";
            body += "<div style='text-align: center; background-color: #eef1fa; height: 100px; padding-top: 50px;'>";
            body += "<p style='text-align: center;'>Copyright &copy; All rights are reserved</p>";
            body += "</div>";

            return body;
        }

        public static string PasswordReset(string email, string code)
        {
            string body = string.Empty;

            body += "<div style='background-color: #444; color: #fff; font-family: sans-serif; text-align: center; padding:30px 20px;'>";
            body += "<div><span style='color: #3EC1D5;'> Medi </span><span style='color: gold;'> Connect </span></div>";
            body += "<div></div>";
            body += "<div><h1> Reset Password! </h1></div>";
            body += "<div style='margin-bottom: 30px;'><p style='font-size: 11px;'> Click the Reset button to reset your password. The link is valid for 10 minutes only. </p></div>";
            body += "<div><a style='border: none; text-decoration: none; background-color: #fc5c63; color: white; padding: 10px 20px;' href='http://localhost:53990/PasswordReset.aspx?token=" + code + "&email=" + MyCryptography.Base64Encode(email) + "'> Reset Password </a></div>";
            body += "</div>";
            body += "<div style='text-align: center; background-color: #eef1fa; height: 100px; padding-top: 50px;'>";
            body += "<p style='text-align: center;'>Copyright &copy; All rights are reserved</p>";
            body += "</div>";

            return body;
        }
    }
}
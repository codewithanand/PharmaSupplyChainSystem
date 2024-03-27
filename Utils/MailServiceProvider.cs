using System.Net.Mail;
using System.Threading;

namespace MediConnect.Utils
{
    public class MailServiceProvider
    {
        private static string host = "smtp.gmail.com";
        private static int port = 587;
        private static string username = "flexifit.technsl@gmail.com";
        private static string password = "kkkwconnwqdvphlq";
        private static string from = "flexifit.technsl@gmail.com";

        public static void SendMail(string to, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = host;
            smtp.Credentials = new System.Net.NetworkCredential(username, password);

            MailMessage mail = new MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress(from);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtp.Send(mail);
        }
    }
}
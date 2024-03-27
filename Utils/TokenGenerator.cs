using System;
using System.Text;

namespace MediConnect.Utils
{
    public class TokenGenerator
    {
        public static string ActivationCode(int length)
        {
            const string chars = "0123456789";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = rand.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }

        public static string Token(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ@#0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i=0; i<length; i++)
            {
                int index = rand.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }
    }
}
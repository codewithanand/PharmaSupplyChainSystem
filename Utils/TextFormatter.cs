using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MediConnect.Utils
{
    public class TextFormatter
    {
        public static string Slugify(string text)
        {
            string slug = Regex.Replace(text, @"[^a-zA-Z0-9\s-]", "");
            slug = slug.Replace(' ', '-').ToLower();
            slug = Regex.Replace(slug, @"-+", "-");
            slug = slug.Trim('-');
            return slug;
        }

        public static DateTime ConvertTextToDate(string dateText)
        {
            string[] formats = { "dd-MM-yyyy", "dd-MM-yy", "dd/MM/yyyy", "dd/MM/yy" };
            DateTime dateValue;
            if (DateTime.TryParseExact(dateText, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                return dateValue;
            }
            else
            {
                throw new ArgumentException("Invalid date format");
            }
        }
    }
}
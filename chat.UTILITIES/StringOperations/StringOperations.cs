using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace chat.UTILITIES.StringOperations
{
    public class StringManager
    {
        public static string ToSlug(string incomingText)
        {
            incomingText = incomingText.Replace("ş", "s");
            incomingText = incomingText.Replace("Ş", "s");
            incomingText = incomingText.Replace("İ", "i");
            incomingText = incomingText.Replace("I", "i");
            incomingText = incomingText.Replace("ı", "i");
            incomingText = incomingText.Replace("ö", "o");
            incomingText = incomingText.Replace("Ö", "o");
            incomingText = incomingText.Replace("ü", "u");
            incomingText = incomingText.Replace("Ü", "u");
            incomingText = incomingText.Replace("Ç", "c");
            incomingText = incomingText.Replace("ç", "c");
            incomingText = incomingText.Replace("ğ", "g");
            incomingText = incomingText.Replace("Ğ", "g");
            incomingText = incomingText.Replace(" ", "-");
            incomingText = incomingText.Replace("---", "-");
            incomingText = incomingText.Replace("?", "");
            incomingText = incomingText.Replace("/", "");
            incomingText = incomingText.Replace(".", "");
            incomingText = incomingText.Replace("'", "");
            incomingText = incomingText.Replace("#", "");
            incomingText = incomingText.Replace("%", "");
            incomingText = incomingText.Replace("&", "");
            incomingText = incomingText.Replace("*", "");
            incomingText = incomingText.Replace("!", "");
            incomingText = incomingText.Replace("@", "");
            incomingText = incomingText.Replace("+", "");
            incomingText = incomingText.ToLower();
            incomingText = incomingText.Trim();

            // tüm harfleri küçült
            string encodedUrl = (incomingText ?? "").ToLower();

            // & ile " " yer değiştirme
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");

            // " " karakterlerini silme
            encodedUrl = encodedUrl.Replace("'", "");

            // geçersiz karakterleri sil
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

            // tekrar edenleri sil
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

            // karakterlerin arasına tire koy
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }
    }
}

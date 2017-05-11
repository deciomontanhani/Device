using System;
using System.Text.RegularExpressions;

namespace ProdutoWeb.Helper
{
    public class UrlFormat
    {

        public static String UrlAmigavel(string url)
        {
            url = url.Replace(' ', '-');
            url = Regex.Replace(url, @"[^A-Za-z0-9'()\*\\+_~\:\/\?\-\.,;=#\[\]@!$&]", "");
            url = Regex.Replace(url, @"\W+", "-");
            return url;
        }

    }
}
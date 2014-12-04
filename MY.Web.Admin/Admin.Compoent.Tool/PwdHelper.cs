using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Compoent.Tool
{
    public  static class PwdHelper
    {
        public static string GetCookieKey()
        {
            return ConfigurationManager.AppSettings["CookieKey"];
        }
        public static string GetCookieIv()
        {
            return ConfigurationManager.AppSettings["CookieIv"];
        }
        public static string GetNewCookieKey()
        {
            return ConfigurationManager.AppSettings["CookieNewKey"];
        }
        public static string GetNewCookieIv()
        {
            return ConfigurationManager.AppSettings["CookieNewIv"];
        }
        public static string GetNewCookieTime()
        {
            return ConfigurationManager.AppSettings["CookieTime"];
        }

        public static int ToInt(this String str)
        {
            return int.Parse(str);
        }
    }
}

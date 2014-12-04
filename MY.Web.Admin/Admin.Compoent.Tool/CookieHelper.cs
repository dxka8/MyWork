using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Admin.Compoent.Tool
{
    public static class CookieHelper
    {
        #region 01.加密解密

        #region 加密
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="sy">支持TripleDESCryptoServiceProvider(三层加密24字符KEY,IV)跟DESCryptoServiceProvider加密(普通加密8字符KEY,IV)</param>
        /// <returns></returns>
        public static string Encrypt(string sourceString, string key, string iv, SymmetricAlgorithm sy)
        {

            try
            {
                var btKey = Encoding.UTF8.GetBytes(key);

                var btIv = Encoding.UTF8.GetBytes(iv);             

                using (var ms = new MemoryStream())
                {
                    var inData = Encoding.UTF8.GetBytes(sourceString);
                    try
                    {
                        using (var cs = new CryptoStream(ms, sy.CreateEncryptor(btKey, btIv), CryptoStreamMode.Write))
                        {
                            cs.Write(inData, 0, inData.Length);

                            cs.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                    catch
                    {
                        //todo:异常处理
                        return sourceString;
                    }
                }
            }
            catch { }

            return "DES加密出错";
        }

        /// <summary>
        /// 支持TripleDESCryptoServiceProvider(三层加密24字符KEY,IV)跟DESCryptoServiceProvider加密(普通加密8字符KEY,IV)
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="btKey"></param>
        /// <param name="btIv"></param>
        /// <param name="sy"></param>
        /// <returns></returns>
        public static string Encrypt(string sourceString, byte[] btKey, byte[] btIv, SymmetricAlgorithm sy)
        {

            try
            {


                using (var ms = new MemoryStream())
                {
                    var inData = Encoding.UTF8.GetBytes(sourceString);
                    try
                    {
                        using (var cs = new CryptoStream(ms, sy.CreateEncryptor(btKey, btIv), CryptoStreamMode.Write))
                        {
                            cs.Write(inData, 0, inData.Length);

                            cs.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                    catch
                    {
                        //todo:异常处理
                        return sourceString;
                    }
                }
            }
            catch { }

            return "DES加密出错";
        }
        #endregion

        #region 解密
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="sy">支持TripleDESCryptoServiceProvider(三层加密24字符KEY,IV)跟DESCryptoServiceProvider加密(普通加密8字符KEY,IV)</param>
        /// <returns></returns>
        public static string Decrypt(string encryptedString, string key, string iv, SymmetricAlgorithm sy)
        {
            var btKey = Encoding.UTF8.GetBytes(key);

            var btIv = Encoding.UTF8.GetBytes(iv);
      
            using (var ms = new MemoryStream())
            {
                var inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (var cs = new CryptoStream(ms, sy.CreateDecryptor(btKey, btIv), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);

                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    //todo:异常处理
                    return encryptedString;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <param name="btKey"></param>
        /// <param name="btIv"></param>
        /// <param name="sy">支持TripleDESCryptoServiceProvider(三层加密24字符KEY,IV)跟DESCryptoServiceProvider加密(普通加密8字符KEY,IV)</param>
        /// <returns></returns>
        public static string Decrypt(string encryptedString, byte[] btKey, byte[] btIv, SymmetricAlgorithm sy)
        {          
            using (var ms = new MemoryStream())
            {
                var inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (var cs = new CryptoStream(ms, sy.CreateDecryptor(btKey, btIv), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);

                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    //todo:异常处理
                    return encryptedString;
                }
            }
        }
        #endregion

        /// <summary>
        /// 写cookie值 常用(默认值15天)
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key"></param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {          
            strValue = Encrypt(strValue, PwdHelper.GetNewCookieKey(), PwdHelper.GetNewCookieIv(), new DESCryptoServiceProvider());
            var cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie[key] = HttpContext.Current.Server.UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(PwdHelper.GetNewCookieTime().ToInt());  
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string key, string strValue,int time)
        {
            strValue = Encrypt(strValue, PwdHelper.GetNewCookieKey(), PwdHelper.GetNewCookieIv(), new DESCryptoServiceProvider());
            var cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie[key] = HttpContext.Current.Server.UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddDays(time);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值 常用(默认值15天)
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key"></param>
        /// <returns>cookie值如果为NULL说明Cookie不合法</returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies[strName] != null &&
                HttpContext.Current.Request.Cookies[strName][key] != null)
            {
                var value = HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Cookies[strName][key]);
                var trueValue= Decrypt(HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Cookies[strName][key]),
                    PwdHelper.GetNewCookieKey(), PwdHelper.GetNewCookieIv(), new DESCryptoServiceProvider());
                if (value == trueValue)
                {
                     trueValue = Decrypt(HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Cookies[strName][key]),
                     PwdHelper.GetCookieKey(), PwdHelper.GetCookieIv(), new DESCryptoServiceProvider());
                       
                     if (value == trueValue)
                     {
                         return null;
                     }
                     WriteCookie(strName, key, trueValue);
                    return trueValue;
                }
                else
                {
                    return trueValue;
                }
                
            }
            return null;


        }
        #endregion


        

    }

    
}

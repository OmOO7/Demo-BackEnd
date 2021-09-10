using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace APIDemo
{
    public class GeneralFunction
    {
        const string EncrptKey = "kSeranSrSvA";
        static Logger Logger;
        static GeneralFunction()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }
        public static HttpResponseMessage Result(HttpResponseMessage content, string status, string DispalyMessage, dynamic result)
        {
            try
            {
                content.StatusCode = HttpStatusCode.OK;
                JObject JO = new JObject(new JProperty("status", status),
                                                   new JProperty("message", DispalyMessage),
                                                   new JProperty("result", JToken.FromObject(result)));
                content.Content = new StringContent(JsonConvert.SerializeObject(JO, Formatting.Indented), Encoding.UTF8, "application/json");
                return content;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error!");
                throw ex;
            }
        }
        public static HttpResponseMessage Result(HttpResponseMessage content, dynamic result)
        {
            try
            {
                content.StatusCode = HttpStatusCode.OK;
                JObject JO = new JObject(new JProperty("result", JToken.FromObject(result)));
                content.Content = new StringContent(JsonConvert.SerializeObject(JO, Formatting.Indented), Encoding.UTF8, "application/json");
                return content;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error!");
                throw ex;
            }
        }
        //public static string Encrypt(string str)
        //{
        //    var oCrypto = new CryptoLibrary.EncryptDecrypt();
        //    return oCrypto.EncryptString(str, EncrptKey);
        //}
        //public static string Decrypt(string str)
        //{
        //    var oCrypto = new CryptoLibrary.EncryptDecrypt();
        //    return oCrypto.DecryptString(str, EncrptKey);
        //}
        public static string Encrypt_(string str)
        {
            try
            {

                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error!");
                throw ex;
            }


        }

        /// <summary>
        /// Decrypt
        /// </summary>

        public static string Decrypt_(string str)
        {
            try
            {
                str = str.Replace(" ", "+");
                string DecryptKey = "2019Feb08CW";
                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                byte[] inputByteArray = new byte[str.Length];
                byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error!");
                throw ex;
            }
        }
    }
}
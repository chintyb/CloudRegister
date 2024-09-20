using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WindowsFormsApp1
{
    internal class NBIotHttpOffline
    {
        public static CookieContainer cookies = new CookieContainer();

        public static HttpWebRequest CreateHttpWebRequestPost(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "application/json";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.CookieContainer = cookies;
            return request;
        }

        public static bool Login(WebRequest request)
        {
            string rawStr = "userno=mis&password=mis_Chintyb888&clientip=&processorid=%2F";
            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            streamWriter.Write(rawStr);
            streamWriter.Close();

            HttpResponseLogin login = ReadFromResponse<HttpResponseLogin>(request);
            if (login.success) return true;
            return false;
        }

        public static HttpWebRequest CreateHttpWebRequestGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.Accept = "application/json";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.CookieContainer = cookies;
            return request;
        }


        public static void WriteToRequest<T>(WebRequest request, T data)
        {
            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            string strJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            streamWriter.Write(strJson);
            streamWriter.Close();
        }

        public static void WriteToRequest(WebRequest request, Dictionary<string,string> data)
        {
            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            //string strJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            //FormUrlEncodedContent form = new FormUrlEncodedContent (data);
            //string str = form.ToString();
            var formStr = string.Join("&", data.Select(kv=> $"{kv.Key}={HttpUtility.UrlEncode(kv.Value)}"));
            //var formCtx = new StringContent(formStr, Encoding.UTF8, "application/x-www-form-urlencoded");
            //string str = formCtx.();
            streamWriter.Write(formStr);
            streamWriter.Close();
        }

        public static T ReadFromResponse<T>(WebRequest request) where T : class
        {
            T res;
            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string data = streamReader.ReadToEnd();
            res = JsonConvert.DeserializeObject<T>(data);
            return res;
        }
    }
}

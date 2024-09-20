using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;

namespace WindowsFormsApp1
{
    internal class NBIotHttp
    {
        public static HttpWebRequest CreateHttpWebRequestPost(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "application/json";
            request.ContentType = "application/json;charset=utf-8";
            return request;
        }

        public static HttpWebRequest CreateHttpWebRequestGet(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.Accept = "application/json";
            request.ContentType = "application/json;charset=utf-8";
            return request;
        }

        public static void WriteToRequest<T>(WebRequest request, T data)
        {
            StreamWriter streamWriter = new StreamWriter(request.GetRequestStream());
            string strJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            streamWriter.Write(strJson);
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

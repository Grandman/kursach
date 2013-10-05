using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace KursachV3
{
    static class HttpRequest
    {
        private static HttpWebRequest CreateRequest(string url, string method)
        {
            int timeout = Convert.ToInt16(ConfigurationManager.AppSettings["timeout"]);
            string userAgent = ConfigurationManager.AppSettings["userAgent"];

            try
            {
                var uri = new Uri(url);
                var request = (HttpWebRequest)WebRequest.Create(uri);
                if (method != "GET")
                {
                    WebRequest.DefaultWebProxy = new WebProxy();
                    request.Timeout = timeout;
                    request.UserAgent = userAgent;
                    var policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                    HttpWebRequest.DefaultCachePolicy = policy;
                    var noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                    request.CachePolicy = noCachePolicy;
                }
                return request;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }
        private static HttpWebRequest WriteParamsToRequest(HttpWebRequest request, string data)
        {
            if (data != null)
            {
                request.ContentType = ConfigurationManager.AppSettings["contentType"];

                var byteData = Encoding.UTF8.GetBytes(data);
                request.ContentLength = byteData.Length;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(byteData, 0, byteData.Length);
                }
            }
            return request;
        }
        public static string GetResponse(string url, string data, string method)
        {
            var defaultEncoding = Encoding.UTF8;
            if (url == null)
                return null;
            try
            {
                var request = CreateRequest(url, method);
                request.Method = method;
                if (method != "GET")
                {
                    request = WriteParamsToRequest(request, data);
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    var responseEncoding = defaultEncoding;
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream, responseEncoding, true))
                        {
                            return reader.ReadToEnd();
                        }
                }
            }
            catch (Exception err)
            {
                var errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (errorCode != 2 && errorCode != 0 && errorCode != 11004)
                {
                    MessageBox.Show(err.Message, errorCode.ToString(CultureInfo.InvariantCulture));
                }
                return null;
            }
            return null;
        }
    }
}

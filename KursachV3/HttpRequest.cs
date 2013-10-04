using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Windows.Forms;

namespace KursachV3
{
    static class HttpRequest
    {
        public static string GetResponse(string url, string data, string method)
        {
            var defaultEncoding = Encoding.UTF8;

            if (url == null) return null;
            Uri uri;

            try
            {
                if (url.Substring(0, 7) != "http://") url = "http://" + url;
                uri = new Uri(url);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri);
                if(method!="GET")
                {
                    WebRequest.DefaultWebProxy = new WebProxy();
                    request.Timeout = 15000;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11";
                    request.Method = method;

                    var policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                    HttpWebRequest.DefaultCachePolicy = policy;
                    var noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                    request.CachePolicy = noCachePolicy;

                    if (data != null)
                    {
                        request.ContentType = "application/x-www-form-urlencoded";

                        var byteData = Encoding.UTF8.GetBytes(data);
                        request.ContentLength = byteData.Length;
                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(byteData, 0, byteData.Length);
                        }
                    }
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

using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Common.Utilities
{
    public class NetHelper
    {
        public static WebProxy CreateWebProxy()
        {
            if (Config.isWebProxy == 1)
            {
                WebProxy proxyObject = new WebProxy(Config.webProxyUrl, int.Parse(Config.webProxyPort));
                proxyObject.Credentials = new NetworkCredential(Config.webProxyUserName, Config.webProxyPassword, Config.webProxyDomain);

                return proxyObject;
            }
            return null;
        }

        //Https 不验证证书
        public static void CancelCertificateValidate()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
        }
        public static string Post(string url,string data)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = CreateWebProxy();
                    wc.Encoding = Encoding.UTF8;
                    CancelCertificateValidate();
                    var respones = wc.UploadString(url, "POST", data);
                    return respones;
                }
            }
            catch
            {
                throw;
            }
        }
        public static string Get(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = CreateWebProxy();
                    wc.Encoding = Encoding.UTF8;
                    CancelCertificateValidate();
                    var respones = wc.DownloadString(url);
                    return respones;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

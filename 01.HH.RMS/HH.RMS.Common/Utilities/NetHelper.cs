using HH.RMS.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        public static string Post(string url, string data, Encoding encode = null)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = CreateWebProxy();
                    if (encode == null)
                        wc.Encoding = Encoding.UTF8;
                    else
                        wc.Encoding = encode;
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
        public static string Get(string url, Encoding encode = null)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = CreateWebProxy();
                    if (encode == null)
                        wc.Encoding = Encoding.UTF8;
                    else
                        wc.Encoding = encode;
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

        public static void DownLoadFile(string fileUrl, string savePath, Encoding encode = null)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = CreateWebProxy();
                    if (encode == null)
                        wc.Encoding = Encoding.UTF8;
                    else
                        wc.Encoding = encode;
                    //保存路径
                    string SaveFilePath = HttpContext.Current.Server.MapPath(savePath);
                    //下载并保存文件
                    wc.DownloadFile(fileUrl, SaveFilePath);
                }
            }
            catch
            {
                throw;
            }
        }
        public static string GetHtmlPage(string url,Encoding encode = null)
        {
            string result = "";
            byte[] bytes = null;
            if (encode == null)
                encode = Encoding.UTF8;               
            try
            {
                using(WebClient wc = new WebClient())
                {
                    wc.Proxy = CreateWebProxy();
                    wc.Encoding = encode;
                    bytes = wc.DownloadData(url);
                    
                }
                result = encode.GetString(bytes); 
                return result;
            }
            catch
            {
                throw;
            }

        }
    }
}

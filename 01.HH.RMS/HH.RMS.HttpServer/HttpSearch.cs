using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.HttpServer
{
    public class HttpSearch : IDisposable
    {
        private HttpListener listener;
        public void Start()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/");
            listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication | AuthenticationSchemes.Anonymous;

            listener.Start();
            listener.BeginGetContext(GetContext, null);
        }

        private void GetContext(IAsyncResult ar)
        {
            HttpListenerRequest Request;
            HttpListenerResponse Response;

            try
            {
                HttpListenerContext ctx = listener.GetContext();
                Request = ctx.Request;
                Response = ctx.Response;

                //setup waiting for the next request
               listener.BeginGetContext(GetContext, null);
            }
            catch (InvalidOperationException)
            {
                return;
            }
            catch (HttpListenerException)
            {
                return;
            }
            
            Response.Close();
            
            //try
            //{
            //    Stream stream = (Stream)Response.OutputStream;
            //    StreamReader reader = new StreamReader(stream);  
            //    var sw = new StreamWriter(Response.OutputStream);
            //    sw.Write("33");
            //    sw.Flush();
            //}
            //finally
            //{
            //    Response.OutputStream.Flush();
            //    Response.Close();
            //}
        }

        public void Dispose()
        {
            if (listener != null)
                listener.Stop();
        }
    }
}

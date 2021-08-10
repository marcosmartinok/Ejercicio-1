using System;
using System.IO;
using System.Net;

namespace EjercicioUno
{
    public class Downloader
    {
        private string url;
        public string Url {get{return url;} set { url = value; }}
        public Downloader(string url) 
        {
            this.url = url;
        }

        public string Download()
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            reader.Close();
            stream.Close();
            response.Close();
            return result;
        }
    }
}
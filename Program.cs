using System;
using System.IO;
using System.Reflection;
using System.Collections;

namespace EjercicioUno
{
    class Program
    {
        static void Main(string[] args)
        {
            const String fileName = "archivo.txt";

            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            UriBuilder builder = new UriBuilder("file", "", 0, path);
            String uri = builder.Uri.ToString();

            Downloader downloader = new Downloader(uri);
            string content;
            content = downloader.Download();

            HTMLReader reader = new HTMLReader(content);
            reader.AdjustText();
        
            HTML html = new HTML(reader.text);
            html.TagCreator();
            html.AtributeCreator();
        
            foreach(Tag item in html.Tags)
            {
                System.Console.WriteLine(item.Name);
            }
            foreach(Attribute item in html.Attributes)
            {
                System.Console.WriteLine("{0}={1}", item.Key, item.Value);
            }

           

        }
    }
}

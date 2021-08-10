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

            System.Console.WriteLine(content);
            

            HTMLReader reader = new HTMLReader(content);
            

            foreach(string item in reader.TagIdentifier())
            {
                System.Console.WriteLine(item);
            }
            foreach(string item in reader.AtributeIdentifier())
            {
                System.Console.WriteLine(item);
            }

           

        }
    }
}

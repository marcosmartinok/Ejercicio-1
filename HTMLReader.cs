using System;
using System.Collections;
using System.Text;

namespace EjercicioUno
{
    
    public class HTMLReader
    {
        public string text;

        public HTMLReader(string text)
        {
            this.text = text;
        }

        public void AdjustText()
        {
            StringBuilder builder = new StringBuilder();
            string[] h = this.text.Split("\r\n");

            foreach (string item in h)
            {
                builder.Append(item.Trim());
                builder.Append(" ");
            }
            this.text = builder.ToString();
        }

        
        
    }
}
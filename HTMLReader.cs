using System;
using System.Collections;

namespace EjercicioUno
{
    
    public class HTMLReader
    {
        private string text;

        public HTMLReader(string text)
        {
            this.text = text;
        }

        public ArrayList TagIdentifier()
        {
            string text = this.text;
            string[] tagContent = text.Split("<");

            ArrayList tag = new ArrayList();

            foreach (string item in tagContent)
            {
                if(item.Contains('='))
                {
                    int space = item.IndexOf(" ");
                    tag.Add(item.Remove(space));
                }
                else if (item.Contains('/'))
                {
                    int slash = item.IndexOf("/");
                    string remove = item.Remove(slash);
                    if (!string.IsNullOrEmpty(remove))
                    {
                        tag.Add(remove);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        tag.Add(item.TrimEnd('>'));
                    }
                    
                }                                
            } 

            return tag;
        }
        public ArrayList AtributeIdentifier()
        {
            string text = this.text;
            string[] atributeContent = text.Split("<");

            ArrayList atribute = new ArrayList();
            foreach (string item in atributeContent)
            {
                if(item.Contains('='))
                {
                    int closeTag = item.IndexOf('>');
                    int space = item.IndexOf(' ');
                    string remove = item.Remove(closeTag).Substring(space).Trim(' ', '/');
                    int length = remove.Length;
                    int counter = 0;
                    int index = 0;
                    for (int i = 0; i < length; i++)
                    {
                       if (remove[i] == '\"')
                       {
                           counter++;
                       }
                       if (counter == 2)
                       {
                           atribute.Add(remove.Substring(index, i - index+1).Trim());
                           counter = 0;
                           index = i+1;
                       }
                    }
                    
                }
            }
            return atribute;
            
        }
    }
}
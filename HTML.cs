using System;
using System.Collections;

namespace EjercicioUno
{
    
    public class HTML
    {
        string Text {get;set;}
        public ArrayList Tags {get;set;}
        public ArrayList Attributes {get;set;}
        public HTML(string text)
        {
            this.Text = text;
            this.Tags = new ArrayList();
            this.Attributes = new ArrayList();
        }

        public void TagCreator()
        {
            string text = this.Text;
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
                        tag.Add(item.TrimEnd(' ', '>'));
                    }
                    
                }                                
            } 
            foreach (string item in tag)
            {
                ITag itag = new Tag(item);
                this.Tags.Add(itag);
            }
        }

        public void AtributeCreator() 
        {
            string text = this.Text;
            string[] attributeContent = text.Split("<");

            ArrayList attribute = new ArrayList();
            foreach (string item in attributeContent)
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
                           attribute.Add(remove.Substring(index, i - index+1).Trim());
                           counter = 0;
                           index = i+1;
                       }
                    }
                    
                }
            }
              
            foreach (string item in attribute)
            {
                int index = item.IndexOf('=');
                string key = item.Substring(0,index);
                string value = item.Substring(index+1).Trim('\"');

                IAttribute iattribute = new Attribute(key, value);
                this.Attributes.Add(iattribute);
            }
        }
    }
}
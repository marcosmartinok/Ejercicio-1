using System;
using System.Collections;
using System.Text;

namespace EjercicioUno
{
    
    public class HTMLBuilder : IHTMLBuilder
    {
        public string Text {get;set;}

        public HTMLBuilder(string text)
        {
            this.Text = text;
        }

        public HTML BuildHTML()
        {
            AdjustText();

            ArrayList tag = TagCreator();
            ArrayList attribute = AttributeCreator();
            ArrayList content = GetContent();

            HTML html = new HTML(tag, attribute, content);
            return html;
        }

        public void AdjustText()
        {
            StringBuilder builder = new StringBuilder();
            string[] h = this.Text.Split("\r\n");
    
            foreach (string item in h)
            {
                builder.Append(item.Trim());
                builder.Append(" ");
            }
            this.Text = builder.ToString();
        }

        public ArrayList TagCreator()
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
            ArrayList tags = new ArrayList();
            foreach (string item in tag)
            {
                ITag itag = new Tag(item);
                tags.Add(itag);
            } 
            return tags;
        }

        public ArrayList AttributeCreator() 
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
            ArrayList attr = new ArrayList();
            foreach (string item in attribute)
            {
                int index = item.IndexOf('=');
                string key = item.Substring(0,index);
                string value = item.Substring(index+1).Trim('\"');

                IAttribute iattribute = new Attribute(key, value);
                attr.Add(iattribute);
            }
            return attr;
        }
        public ArrayList GetContent() //agregar logica
        {
            ArrayList content = new ArrayList();
            return content;
        }

        
        
    }
}
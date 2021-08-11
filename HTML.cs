using System;
using System.Collections;

namespace EjercicioUno
{
    public class HTML
    {
        public ArrayList Tags {get;set;}
        public ArrayList Attributes {get;set;}
        public ArrayList Content {get;set;}
        public HTML(ArrayList tags, ArrayList attributes, ArrayList content)
        {
            this.Tags = tags;
            this.Attributes = attributes;
            this.Content = content;
        }       

        public ArrayList ListOfTags()
        {
            ArrayList list  = new ArrayList();
            foreach (Tag item in this.Tags)
            {
                list.Add(item.Name);
            }
            return list;
        }
        public ArrayList ListOfAttributes()
        {
            ArrayList list = new ArrayList();
            foreach (Attribute item in this.Attributes)
            {
                string attribute = $"{item.Key}={item.Value}";
                list.Add(attribute);
            }
            return list;
        }
    }
}
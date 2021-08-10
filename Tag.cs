using System;
using System.Collections;

namespace EjercicioUno
{
    
    public class Tag : ITag
    {
        public string Name {get;set;}
        public ArrayList Atributes {get;set;}
        public string Content {get;set;}
      
        public Tag(string name)
        {
            this.Name = name;  
            this.Atributes = new ArrayList();
            this.Content = "";
        }
       
       
    }
}
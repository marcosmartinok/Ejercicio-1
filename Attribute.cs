using System;
using System.Collections;

namespace EjercicioUno
{
    
    public class Attribute : IAttribute
    {
        public string Key {get;set;}
        public string Value {get;set;}
        public Attribute(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
        
    }
}
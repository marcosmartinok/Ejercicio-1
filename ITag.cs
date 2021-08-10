using System;
using System.Collections;

namespace EjercicioUno
{
    
    public interface ITag
    {
        public string Name {get;set;}
        public ArrayList Atributes {get;set;}
        public string Content {get;set;}
    }
}
using System;
using System.Collections;

namespace EjercicioUno
{
    
    public interface IHTMLBuilder
    {
        public string Text {get;set;}

        HTML BuildHTML();
        void AdjustText();
        ArrayList TagCreator();
        ArrayList AttributeCreator();
        ArrayList GetContent();
        

       
    }
}
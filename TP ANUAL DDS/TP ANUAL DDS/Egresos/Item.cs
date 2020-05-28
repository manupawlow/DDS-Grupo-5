using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    class Item
    {
        public string descripcion { get; }

        public float valor { get; set; }
     
        public Item (float Precio, string Descipcion)
        {
            descripcion = Descipcion;
            valor = Precio;
        }

        

    }
}

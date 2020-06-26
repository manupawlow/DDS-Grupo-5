using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    public class Item
    {
        public string descripcion { get; set; }

        public List<Criterio> criterio = new List<Criterio>();
     
        public Item (string Descripcion)
        {
            descripcion = Descripcion;
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public class Item
    {
        public string descripcion { get; set; }
        public float valor { get; set; }
        public List<Criterio> criterio = new List<Criterio>();

        public Item(float Valor, string Descripcion )
        {
            valor = Valor;
            descripcion = Descripcion;
        }



    }
}

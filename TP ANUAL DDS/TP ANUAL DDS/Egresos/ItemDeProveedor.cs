using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    public class ItemDeProveedor
    {
        public string descripcion { get; set; }

        public List<Criterio> criterio = new List<Criterio>();

        public float valor { get; set; }

        public ItemDeProveedor(float Precio, string Descipcion)
        {
            descripcion = Descipcion;
            valor = Precio;
        }
    }
}
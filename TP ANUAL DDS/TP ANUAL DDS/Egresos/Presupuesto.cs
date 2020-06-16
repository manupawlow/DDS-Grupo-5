using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    public class Presupuesto
    {
        public List<ItemDeProveedor> itemsDePresupuesto = new List<ItemDeProveedor>();
        public float valorTotal;
        public DocumentoComercial documentoComercial;
    }
}

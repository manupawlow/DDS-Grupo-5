using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    class Presupuesto
    {
        public List<ItemDeProveedor> itemsDePresupuesto = new List<ItemDeProveedor>();
        public float valorTotal;
        public DocumentoComercial documentoComercial;
    }
}

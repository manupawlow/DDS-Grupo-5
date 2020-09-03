using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_Anual.Egresos
{
    public class Presupuesto
    {
        public List<Item> itemsDePresupuesto = new List<Item>();
        public float valorTotal { get; set; }
        public DocumentoComercial documentoComercial;
        public Proveedor proveedor;

        public Presupuesto(DocumentoComercial Doc, Proveedor Prov)
        {
            documentoComercial = Doc;
            proveedor = Prov;
            valorTotal = itemsDePresupuesto.Sum(items => items.valor);
        }

        public void agregar_item(Item Item)
        {
            itemsDePresupuesto.Add(Item);
            valorTotal = itemsDePresupuesto.Sum(items => items.valor);
        }
    }
}

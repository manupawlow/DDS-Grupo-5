using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TP_ANUAL_DDS.Egresos
{
    class Egreso
    {
        private DocumentoComercial documentoComercial;
        private DateTime fecha;
        private List<Item> items = new List<Item>();
        private MedioDePago medioDePago;
        private Proveedor proveedor;
        public float valorTotal;
        public int cantPresupuesto;

       
        public Egreso(DateTime Fecha, DocumentoComercial Doc, Proveedor Prov, MedioDePago Medio)
        {
            fecha = Fecha;
            documentoComercial = Doc;
            proveedor = Prov;
            medioDePago = Medio;

        }
        
        public void agregarItem(Item item) 
        {
            items.Add(item);
        }

        public void calcularValorTotal()
        {
            valorTotal = items.Sum(item => item.valor);

        }

    }
}

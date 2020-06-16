using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    public class Proveedor
    {
        private long cuit;
        private int direccionPostal;
        private Egreso egreso;
        private List<ItemDeProveedor> itemsCoincidentes = new List<ItemDeProveedor>();
        private List<ItemDeProveedor> itemsDeProv = new List<ItemDeProveedor>();
        private string razonSocial;
        
        
        public Proveedor(long Cuit, int DireccionPostal, string RazonSocial)
        {
            cuit = Cuit;
            direccionPostal = DireccionPostal;
            razonSocial = RazonSocial;
        }

        public void agregarItem(ItemDeProveedor item)
        {
            itemsDeProv.Add(item);
        }
        public void asignarEgreso(Egreso egres)
        {
            egreso = egres;
            asignarItemsSegunEgreso();
        }
        
        public void asignarItemsSegunEgreso()
        {
            for (int i = 0; i < egreso.items.Count(); i++)
            {
                itemsCoincidentes.Add(itemsDeProv.Find(ItemDeProveedor => ItemDeProveedor.descripcion == egreso.items[i].descripcion));
            }
        }
       
        public Presupuesto presupuesto()
        {
            Presupuesto presup = new Presupuesto();
            presup.itemsDePresupuesto = itemsCoincidentes;
            presup.valorTotal = valorSegunEgreso();
            presup.documentoComercial = egreso.documentoComercial;
            return presup;
        }

        public float valorSegunEgreso()
        {
            return itemsCoincidentes.Sum(itemDeProveedor => itemDeProveedor.valor);
        }

    }
}

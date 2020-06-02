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
        private string razonSocial;
        private Egreso egreso;
        private List<ItemDeProveedor> itemsDeProv = new List<ItemDeProveedor>();
        
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
        }

        public List<ItemDeProveedor> asignarItems()
        {
            List<ItemDeProveedor> itemsCoincidentes = new List<ItemDeProveedor>(); ;
            for (int i=0; i < egreso.items.Count(); i++)
            {
                itemsCoincidentes.Add(itemsDeProv.Find(ItemDeProveedor => ItemDeProveedor.descripcion == egreso.items[i].descripcion));
            }
            return itemsCoincidentes;
        }

        public Presupuesto presupuesto()
        {
            Presupuesto presup = new Presupuesto();
            presup.itemsDeProveedor = asignarItems();
            presup.valorTotal = presup.itemsDeProveedor.Sum(itemDeProveedor => itemDeProveedor.valor);
            return presup;
        }
    }
}

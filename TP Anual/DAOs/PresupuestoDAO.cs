using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class PresupuestoDAO
    {
        public static PresupuestoDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private PresupuestoDAO() { }

        public static PresupuestoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new PresupuestoDAO();
            }

            return instancia;
        }

        #region Funciones
        public Presupuesto getPresupuestoById(int id)
        {
            using (var context = new BaseDeDatos())
            {
                return context.presupuestos.Single(e => e.id_presupuesto == id);
            }
        }

        public List<Presupuesto> getAllPresupuesto()
        {
            using (var context = new BaseDeDatos())
            {
                return context.presupuestos.ToList<Presupuesto>();
            }
        }

        public PresupuestoDAO Add(Presupuesto e)
        {
            using (var context = new BaseDeDatos())
            {
                context.presupuestos.Add(e);
                context.SaveChanges();
            }
            return this;
        }

        public PresupuestoDAO CalcularTotal(Presupuesto p)
        {
            using (var context = new BaseDeDatos())
            {
                p.calcular_total();
                context.SaveChanges();
            }
            return this;
        }

        public PresupuestoDAO cargarPresupuesto(int id_egreso, string CUIT, string[] items, string[] cantidades, string[] precios)
        {
            using (var context = new BaseDeDatos())
            {

                var egreso = context.egresos.First(e => e.id_egreso == id_egreso);
                var proveedor = context.proveedores.First(p => p.CUIT == CUIT);

                Presupuesto nuevo = new Presupuesto();
                nuevo.egreso = egreso;
                nuevo.proveedor = proveedor;

                context.presupuestos.Add(nuevo);
                context.SaveChanges();

                try
                {

                    for (int i = 0; i < items.Length; i++)
                    {
                        //var item = ItemDAO.getInstancia().getItemByDescripcion(items[i]);
                        Item item = new Item();
                        item.descripcion = items[i];
                        context.items.Add(item);
                        context.SaveChanges();

                        //ItemDAO.getInstancia().AddItemPorEgreso(ie);
                        ItemPorPresupuesto ip = new ItemPorPresupuesto();
                        ip.item = item;
                        ip.cantidad = Int32.Parse(cantidades[i]);
                        ip.valor = Int32.Parse(precios[i]);
                        context.items_por_presupuesto.Add(ip);
                        context.SaveChanges();

                        nuevo.itemsDePresupuesto.Add(ip);
                        context.SaveChanges();

                    }

                }
                catch (NullReferenceException) { }
            }

            return this;
        }

        #endregion

    }
}

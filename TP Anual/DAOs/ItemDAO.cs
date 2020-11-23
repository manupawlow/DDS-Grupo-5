using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class ItemDAO
    {
        public static ItemDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private ItemDAO() { }

        public static ItemDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new ItemDAO();
            }

            return instancia;
        }

        #region Funciones
        public Item getItemByDescripcion(string descripcion)
        {
            using (var context = new BaseDeDatos())
            {
                //TODO: Si no existe el item que lo cree en la BD
                //return context.items.Single(i => i.descripcion == descripcion);
                var nn = context.items.Any(i => i.descripcion == descripcion);
                if (nn) {
                    var jj =  context.items.First(i => i.descripcion == descripcion);
                    return jj;
                }
                else
                {
                    var item = new Item();
                    item.descripcion = descripcion;
                    ItemDAO.getInstancia().AddItem(item);
                    return context.items.First(i => i.descripcion == item.descripcion);
                }

                /*try
                {
                    var item = context.items.First(i => i.descripcion == descripcion);
                    return item;
                }
                catch (InvalidOperationException)
                {
                    var item = new Item(descripcion);
                    ItemDAO.getInstancia().AddItem(item);
                    return item;
                }*/
            }
        }

        public ItemDAO AddItemPorEgreso(ItemPorEgreso i)
        {
            using (var context = new BaseDeDatos())
            {
                //Cuando entra un nuevo item me lo carga dos veces aca ?)
                context.items_por_egreso.Add(i);
                context.SaveChanges();
            }
            return this;
        }

        public ItemDAO AddItemPorPresupuesto(ItemPorPresupuesto p)
        {
            using (var context = new BaseDeDatos())
            {
                context.items_por_presupuesto.Add(p);
                context.SaveChanges();
            }
            return this;
        }

        public ItemDAO AddItem(Item i)
        {
            using (var context = new BaseDeDatos())
            {
                context.items.Add(i);
                context.SaveChanges();
            }
            return this;
        }

        public List<ItemPorEgreso> getItemsDeEgreso(int id_egreso)
        {
            using (var context = new BaseDeDatos())
            {
                return context.items_por_egreso.Where(i => i.id_egreso == id_egreso).ToList<ItemPorEgreso>();
            }
        }
        public List<ItemPorPresupuesto> getItemsPorPresupuesto(int id_presupuesto)
        {
            using (var context = new BaseDeDatos())
            {
                return context.items_por_presupuesto.Where(i => i.id_presupuesto == id_presupuesto).ToList<ItemPorPresupuesto>();
            }
        }

        #endregion
    }
}

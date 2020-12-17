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
            using (var context = new MySql())
            {
                try
                {
                    return context.items.First(i => i.descripcion == descripcion);
                }
                catch (InvalidOperationException)
                {
                    return null;       
                }
            }
        }

        public ItemDAO AddItemPorEgreso(ItemPorEgreso i)
        {
            using (var context = new MySql())
            {
                //Cuando entra un nuevo item me lo carga dos veces aca ?)
                context.items_por_egreso.Add(i);
                context.SaveChanges();
            }
            return this;
        }

        public ItemDAO AddItemPorPresupuesto(ItemPorPresupuesto p)
        {
            using (var context = new MySql())
            {
                context.items_por_presupuesto.Add(p);
                context.SaveChanges();
            }
            return this;
        }

        public ItemDAO AddItem(Item i)
        {
            using (var context = new MySql())
            {
                context.items.Add(i);
                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un item de id:{i.id_item}");
            }
            return this;
        }

        public List<ItemPorEgreso> getItemsDeEgreso(int id_egreso)
        {
            using (var context = new MySql())
            {
                return context.items_por_egreso.Include("item").Where(i => i.id_egreso == id_egreso).ToList<ItemPorEgreso>();
            }
        }
        public List<ItemPorPresupuesto> getItemsPorPresupuesto(int id_presupuesto)
        {
            using (var context = new MySql())
            {
                return context.items_por_presupuesto.Include("item").Where(i => i.id_presupuesto == id_presupuesto).ToList<ItemPorPresupuesto>();
            }
        }

        #endregion
    }
}

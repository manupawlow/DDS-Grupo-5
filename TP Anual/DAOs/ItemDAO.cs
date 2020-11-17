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
                return context.items.Single(i => i.descripcion == descripcion);
            }
        }

        public ItemDAO AddItemPorEgreso(ItemPorEgreso e)
        {
            using (var context = new BaseDeDatos())
            {
                context.items_por_egreso.Add(e);
            }
            return this;
        }

        public ItemDAO AddItemPorPresupuesto(ItemPorPresupuesto p)
        {
            using (var context = new BaseDeDatos())
            {
                context.items_por_presupuesto.Add(p);
            }
            return this;
        }

        #endregion
    }
}

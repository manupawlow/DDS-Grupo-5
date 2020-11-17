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
            }
            return this;
        }

        #endregion

    }
}

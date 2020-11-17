using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class EgresoDAO
    {
        public static EgresoDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private EgresoDAO() { }

        public static EgresoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new EgresoDAO();
            }

            return instancia;
        }

        #region Funciones
        public Egreso getEgresoById(int id)
        {
            using (var context = new BaseDeDatos())
            {
                return context.egresos.Single(e => e.id_egreso == id);
            }
        }

        public List<Egreso> getAllEgreso()
        {
            using (var context = new BaseDeDatos())
            {
                return context.egresos.ToList<Egreso>();
            }
        }

        public EgresoDAO Add(Egreso e)
        {
            using (var context = new BaseDeDatos())
            {
                context.egresos.Add(e);
            }
            return this;
        }

        #endregion


    }
}

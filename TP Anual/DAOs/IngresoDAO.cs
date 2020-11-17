using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class IngresoDAO
    {
        public static IngresoDAO instancia = null;
        
        private IngresoDAO() { }

        public static IngresoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new IngresoDAO();
            }

            return instancia;
        }


        #region Funciones
        public Ingreso getIngresoById(int id)
        {
            using (var context = new BaseDeDatos())
            {
                return context.ingresos.Single(e => e.id_ingreso == id);
            }
        }

        public List<Ingreso> getAllIngreso()
        {
            using (var context = new BaseDeDatos())
            {
                return context.ingresos.ToList<Ingreso>();
            }
        }

        public IngresoDAO Add(Ingreso e)
        {
            using (var context = new BaseDeDatos())
            {
                context.ingresos.Add(e);
            }
            return this;
        }

        #endregion


    }
}

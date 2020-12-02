using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual.DAOs
{
    class ProyectoDAO
    {
        public static ProyectoDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private ProyectoDAO() { }

        public static ProyectoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new ProyectoDAO();
            }

            return instancia;
        }

        #region Funciones
        /*public ProyectoDeFinanciamiento cargarProyecto(int monto, int cant)
        {
            using (var context = new BaseDeDatos())
            {
                
            }
        }*/


        #endregion
    }
}

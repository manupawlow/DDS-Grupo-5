using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class ProyectoDAO
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
        public ProyectoDAO cargarProyecto(int cant, int monto, string usuario)
        {
            using (var context = new BaseDeDatos())
            {
                var u = context.usuarios.Single(us => us.nombre == usuario);

                var nuevo = new ProyectoDeFinanciamiento(cant, monto, u);

                context.proyectos.Add(nuevo);

                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un proyecto de financiamiento de id:{nuevo.id}");

            }


            return this;
        }

        public ProyectoDAO vincularIngresoConProyecto(int id_proyecto, int id_ingreso)
        {
            using (var context = new BaseDeDatos())
            {
                var i = context.ingresos.Single(ing => ing.id_ingreso == id_ingreso);
                
                var p = context.proyectos.Single(pr => pr.id == id_proyecto);

                i.proyecto = p;

                p.agregarIngreso(i);

                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha agregado un nuevo ingreso de id: {i.id_ingreso} al proyecto de id:{p.id} ");

            }

            return this;
        }

        public ProyectoDAO bajaProyecto(int id_proyecto)
        {
            using (var context = new BaseDeDatos())
            {
                var p = context.proyectos.Single(pr => pr.id == id_proyecto);

                p.cerrarProyecto();

                context.proyectos.Remove(p);

                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"El proyecto de id:{p.id} se ha dado de baja");
            }

            return this;
        }

        #endregion
    }
}

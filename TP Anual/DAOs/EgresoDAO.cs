using MongoDB.Driver;
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
            using (var context = new MySql())
            {
                try {
                    return context.egresos
                  .Include("items")
                  .Include("presupuestos")
                  .Single(e => e.id_egreso == id);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
                
            }
        }

        public List<Egreso> getAllEgreso()
        {
            using (var context = new MySql())
            {
                return context.egresos
                    .Include("items")
                    .Include("presupuestos")
                    //.Include("ingreso")
                    //.Include("proveedorElegido")
                    .ToList<Egreso>();
            }
        }

        public EgresoDAO cargarEgreso(string descripcion, string revisor, int cantPresup, string[] items = null, string[] cantidades = null)
        {
            using (var context = new MySql())
            {
                var user = UsuarioDAO.getInstancia().getUsuarioByUserName(revisor);

                Egreso nuevo = new Egreso();
                nuevo.cantPresupuestos = cantPresup;
                nuevo.fecha = DateTime.Now;
                nuevo.descripcion = descripcion;
                nuevo.bandejaDeMensajes = new BandejaDeMensajes(user);

                context.egresos.Add(nuevo);
                context.SaveChanges();

                nuevo.bandejaDeMensajes.id_egreso = nuevo.id_egreso;

                MongoDB.getInstancia().registrarBandejaDeMensajes(nuevo);
                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un egreso de id:{nuevo.id_egreso}");
    
            }

            return this;
        }

        public bool validarEgreso(int id_egreso)
        {
            using (var context = new MySql())
            {

                var egreso = context.egresos
                    .Single(e => e.id_egreso == id_egreso);
                bool validacion;

                if (egreso.id_proyecto != 0)
                {
                    egreso = context.egresos
                   .Include("items")
                   .Include("presupuestos")
                   .Include("proyecto")
                   .Single(e => e.id_egreso == id_egreso);   
                }
                else 
                {
                    egreso = context.egresos
                   .Include("items")
                   .Include("presupuestos")
                   .Single(e => e.id_egreso == id_egreso);    
                }

                egreso.criterioDeSeleccion = new MenorValor();

                MongoDB.getInstancia().agregarBandejaAEgresoEnCasoQueNoLaTengaAsignada(egreso);
                validacion = ValidadorDeEgreso.egresoValido(egreso);
                MongoDB.getInstancia().actualizarBandejaDeMensajesNoSQL(egreso);

                return validacion;

            }
        }


        #endregion


    }
}

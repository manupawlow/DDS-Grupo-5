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
            using (var context = new BaseDeDatos())
            {
                return context.egresos
                    .Include("items")
                    .Include("presupuestos")
                    .Single(e => e.id_egreso == id);
            }
        }

        public List<Egreso> getAllEgreso()
        {
            using (var context = new BaseDeDatos())
            {
                return context.egresos
                    .Include("items")
                    .Include("presupuestos")
                    //.Include("ingreso")
                    //.Include("proveedorElegido")
                    .ToList<Egreso>();
            }
        }

        //public Egreso Add(Egreso e)
        //{
        //    using (var context = new BaseDeDatos())
        //    {
        //        context.egresos.Add(e);
        //        context.SaveChanges();
        //        return e;
        //    }
        //}

        //public Egreso agregarItemPorEgreso(Egreso e, ItemPorEgreso i)
        //{
        //    using (var context = new BaseDeDatos())
        //    {
        //        //getEgresoById(id).items.Add(i);
        //        e.items.Add(i);
        //        context.SaveChanges();
        //        return e;
        //    }
        //}


        public EgresoDAO cargarEgreso(string revisor, int cantPresup, string[] items = null, string[] cantidades = null)
        {
            using (var context = new BaseDeDatos())
            {
                var user = UsuarioDAO.getInstancia().getUsuarioByUserName(revisor);

                Egreso nuevo = new Egreso();
                nuevo.cantPresupuestos = 1;
                nuevo.fecha = DateTime.Today;
                nuevo.bandejaDeMensajes = new BandejaDeMensajes(user);

                context.egresos.Add(nuevo);
                context.SaveChanges();

                nuevo.bandejaDeMensajes.id_egreso = nuevo.id_egreso;

                var client = new MongoClient(/*"mongodb+srv://disenio2020:pepepepe@cluster0.unla6.mongodb.net/disenio2020?retryWrites=true&w=majority"*/);
                var database = client.GetDatabase("mydb");
                MongoDB.getInstancia().registrarBandejaDeMensajes(database, user, nuevo);
                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un egreso de id:{nuevo.id_egreso}");

                try
                {
                    if(items != null && cantidades != null)
                        for (int i = 0; i < items.Length; i++)
                        {
                            //var item = ItemDAO.getInstancia().getItemByDescripcion(items[i]);
                            Item item = new Item();
                            item.descripcion = items[i];
                            context.items.Add(item);
                            context.SaveChanges();

                            MongoDB.getInstancia().agregarLogABitacora($"Se ha agregado un item de id:{item.id_item} al egreso de id:{nuevo.id_egreso}");

                            //ItemDAO.getInstancia().AddItemPorEgreso(ie);
                            ItemPorEgreso ie = new ItemPorEgreso();
                            ie.item = item;
                            ie.cantidad = Int32.Parse(cantidades[i]);
                            context.items_por_egreso.Add(ie);
                            context.SaveChanges();

                            nuevo.items.Add(ie);
                            context.SaveChanges();

                        }
                }
                catch (NullReferenceException) { }
            }

            return this;
        }

        public void validarEgreso(int id_egreso)
        {
            using (var context = new BaseDeDatos())
            {
                var egreso = context.egresos
                    .Include("items")
                    .Include("presupuestos")
                    .Include("proyecto")
                    .Single(e => e.id_egreso == id_egreso);

                egreso.criterioDeSeleccion = new MenorValor();

                var client = new MongoClient(/*"mongodb+srv://disenio2020:pepepepe@cluster0.unla6.mongodb.net/disenio2020?retryWrites=true&w=majority"*/);
                var database = client.GetDatabase("mydb");
                var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");
                var listaBandeja = coleccionBandejaDeMensajes.Find(bandeja => bandeja.id_egreso == egreso.id_egreso).ToList();
                egreso.bandejaDeMensajes = listaBandeja[0];

                ValidadorDeEgreso.egresoValido(egreso);

                MongoDB.getInstancia().actualizarBandejaDeMensajesNoSQL(database, egreso);

                context.SaveChanges();
            }
        }

        public string mostrarBandejaDeMensajes(Egreso egreso)
        {
            return MongoDB.getInstancia().mostrarBandejaDeMensajesDeEgreso(egreso);
        }
        #endregion


    }
}

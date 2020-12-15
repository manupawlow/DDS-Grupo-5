using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson;
using TP_Anual.Egresos;
using TP_Anual.Administrador_Inicio_Sesion;

namespace TP_Anual
{
    public class MongoDB
    {
        public static MongoDB instancia = null;
        public bool conectarMongo = true;

        private MongoDB()
        {
            //BsonClassMap.RegisterClassMap<BandejaDeMensajes>();
            //BsonClassMap.RegisterClassMap<Log>();
            //BsonClassMap.RegisterClassMap<BitacoraDeOperaciones>();
        }

        public static MongoDB getInstancia()
        {

            if (instancia == null)
            {
                instancia = new MongoDB();
            }

            return instancia;
        }

        public void actualizarBandejaDeMensajesNoSQL(Egreso egreso)
        {

            if (conectarMongo)
            {
                var client = new MongoClient();
                var database = client.GetDatabase("mydb");

                // Construyo filtro de busqueda
                var builder = Builders<BandejaDeMensajes>.Filter;
                var filter = builder.Where(bandeja => bandeja.id_egreso == egreso.id_egreso);

                // Traigo la coleccion
                var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");

                // Busco usando el filtro y convierto los resultados a lista
                var bandejasDeMensajesEncontradas = coleccionBandejaDeMensajes.Find<BandejaDeMensajes>(filter);
                var listaBandejaDeMensajes = bandejasDeMensajesEncontradas.ToList<BandejaDeMensajes>();
                var bandejaDeMensajes = listaBandejaDeMensajes[0];
                egreso.bandejaDeMensajes.ID = bandejaDeMensajes.ID;

                // Creo una bandeja de mensajes y la inserto
                coleccionBandejaDeMensajes.ReplaceOne(filter, egreso.bandejaDeMensajes);
            }

        }

        public void registrarBandejaDeMensajes(Egreso egreso)
        {
            if (conectarMongo)
            {
                var client = new MongoClient();
                var database = client.GetDatabase("mydb");

                var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");
                coleccionBandejaDeMensajes.InsertOne(egreso.bandejaDeMensajes);
            }

        }

        public void actualizarBitacoraNoSQL(IMongoDatabase database, ObjectId bitacoraID)
        {

            // Construyo filtro de busqueda
            var builder = Builders<BitacoraDeOperaciones>.Filter;
            var filter = builder.Eq(bitacora => bitacora.ID, bitacoraID);

            // Traigo la coleccion
            var coleccionBitacoraDeOperaciones = database.GetCollection<BitacoraDeOperaciones>("coleccionBitacoraDeOperaciones");

            // Busco usando el filtro y convierto los resultados a lista
            var BitacoraDeOperacionesEncontradas = coleccionBitacoraDeOperaciones.Find<BitacoraDeOperaciones>(filter);
            var listaBitacoraDeOperaciones = BitacoraDeOperacionesEncontradas.ToList<BitacoraDeOperaciones>();
            var BitacoraDeOperaciones = listaBitacoraDeOperaciones[0];
            GeneradorDeLogs.bitacora.ID = BitacoraDeOperaciones.ID;

            // Creo una BitacoraDeOperaciones y la inserto
            coleccionBitacoraDeOperaciones.ReplaceOne(filter, GeneradorDeLogs.bitacora);
        }

        public void verificarSiExisteBitacoraPosterior(IMongoDatabase database)
        {
            var coleccionBitacoraDeOperaciones = database.GetCollection<BitacoraDeOperaciones>("coleccionBitacoraDeOperaciones");
            var listaBitacoras = coleccionBitacoraDeOperaciones.Find(bitacora => bitacora.ID != null).ToList();
            GeneradorDeLogs.bitacora = listaBitacoras[0];
        }

        public void traerBitacora(IMongoDatabase database)
        {
            GeneradorDeLogs.bitacora = BitacoraDeOperaciones.GetInstance;
            var coleccionBitacoraDeOperaciones = database.GetCollection<BitacoraDeOperaciones>("coleccionBitacoraDeOperaciones");
            coleccionBitacoraDeOperaciones.InsertOne(GeneradorDeLogs.bitacora);
        }

        public bool verificarSiContieneColeccion(List<string> lista, string coleccion)
        {
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i] == coleccion)
                    return true;
            }
            return false;
        }

        public void registrarBitacoraDeOperaciones(IMongoDatabase database)
        {
            var listaDocumentos = database.ListCollectionNames().ToList();

            if (verificarSiContieneColeccion(listaDocumentos, "coleccionBitacoraDeOperaciones"))
            {
                verificarSiExisteBitacoraPosterior(database);
            }
            else
            {
                traerBitacora(database);
            }

        }

        public void agregarBandejaAEgresoEnCasoQueNoLaTengaAsignada(Egreso egreso)
        {
            if (egreso.bandejaDeMensajes == null)
            {
                if (conectarMongo)
                {
                    var client = new MongoClient();
                    var database = client.GetDatabase("mydb");
                    var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");
                    var listaBandeja = coleccionBandejaDeMensajes.Find(bandeja => bandeja.id_egreso == egreso.id_egreso).ToList();
                    egreso.bandejaDeMensajes = listaBandeja[0];


                }

            }
        }

        public string[] mostrarBandejaDeMensajesDeEgreso(Egreso egreso)
        {

            //var listaDatabases = client.ListDatabaseNames().ToList();
            // var database = client.GetDatabase(listaDatabases[3]);
            if (conectarMongo)
            {
                var client = new MongoClient();
                var database = client.GetDatabase("mydb");

                var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");
                //var filter = Builders<BandejaDeMensajes>.Filter.Eq(bandeja => bandeja.id_egreso, egreso.bandejaDeMensajes.id_egreso);
                var bandejaDeMensajes = coleccionBandejaDeMensajes.Find(bandeja => bandeja.id_egreso == egreso.id_egreso).ToList();

                //var listado = bandejaDeMensajes[0]["mensajes"].ToString();

                //Console.WriteLine(listado);

                return bandejaDeMensajes[0].mensajes.Split('\n');
            }
            else
            {
                return "No se pudo acceder a MongoDB".Split('\n');
            }


        }

        public void agregarLogABitacora(string log)
        {

            if (conectarMongo)
            {
                var client = new MongoClient(/*"mongodb+srv://disenio2020:pepepepe@cluster0.unla6.mongodb.net/disenio2020?retryWrites=true&w=majority"*/);
                var database = client.GetDatabase("mydb");

                registrarBitacoraDeOperaciones(database);

                GeneradorDeLogs.agregarLogABitacora(log);

                actualizarBitacoraNoSQL(database, GeneradorDeLogs.bitacora.ID);
            }


        }

        public string[] mostrarBitacora()
        {
            if (conectarMongo)
            {
                var client = new MongoClient();
                var database = client.GetDatabase("mydb");

                var coleccionBitacoraDeOperaciones = database.GetCollection<BitacoraDeOperaciones>("coleccionBitacoraDeOperaciones");
                var bitacoraDeOperaciones = coleccionBitacoraDeOperaciones.Find(bitacora => bitacora.ID != null).ToList();

                return logToString(bitacoraDeOperaciones[0].logs).Split('\n');
            }
            else
            { 
                return "No se pudo acceder a MongoDB".Split('\n');
            }

        }

        public string logToString(List<Log> logs)
        {
            string cadena = logs[0].accion + "          " + logs[0].fecha.ToString(); 
        
            for(int i=1; i < logs.Count; i++) 
            {
                cadena = cadena + "\n" + logs[i].accion + "          " + logs[i].fecha.ToString();
            }

            return cadena;

        }

    }
}

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
    class MongoDB
    {
        public static MongoDB instancia = null;

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

        public static void actualizarBaseDeDatosNoSQL(IMongoDatabase database, Egreso egreso)
        {
            // Construyo filtro de busqueda
            var builder = Builders<BandejaDeMensajes>.Filter;
            var filter = builder.Where(bandeja => bandeja.revisor.nombre == egreso.bandejaDeMensajes.revisor.nombre);

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

        public static void registrarBandejaDeMensajes(IMongoDatabase database, Usuario revisor, Egreso egreso)
        {
            // Agrego bandeja de mensajes a egreso
            egreso.bandejaDeMensajes = new BandejaDeMensajes(revisor);

            // Traigo la coleccion
            var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");

            // Creo una bandeja de mensajes y la inserto
            var bandejaDeMensajes = new BandejaDeMensajes(revisor);
            coleccionBandejaDeMensajes.InsertOne(bandejaDeMensajes);
        }

        public static void actualizarBitacoraNoSQL(IMongoDatabase database, ObjectId bitacoraID)
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

        public static void registrarBitacoraDeOperaciones(IMongoDatabase database)
        {
            // Agrego BitacoraDeOperaciones a egreso

            // Traigo la coleccion
            var coleccionBitacoraDeOperaciones = database.GetCollection<BitacoraDeOperaciones>("coleccionBitacoraDeOperaciones");
            var listaBitacoras = coleccionBitacoraDeOperaciones.Find(bitacora => bitacora.ID != null).ToList();
            GeneradorDeLogs.bitacora = listaBitacoras[0];
            GeneradorDeLogs.bitacora = BitacoraDeOperaciones.GetInstance;

            // Creo una BitacoraDeOperaciones y la inserto
            coleccionBitacoraDeOperaciones.InsertOne(GeneradorDeLogs.bitacora);
        }

        public static void mostrarBandejaDeMensajesDeEgreso(IMongoDatabase database, Egreso egreso)
        {

            var coleccionBandejaDeMensajes = database.GetCollection<BsonDocument>("coleccionBandejaDeMensajes");
            var filter = Builders<BsonDocument>.Filter.Eq(bandeja => bandeja["revisor"]["nombre"], egreso.bandejaDeMensajes.revisor.nombre);//Where(bandeja => bandeja.revisor.nombre == egreso.bandejaDeMensajes.revisor.nombre);
            var bandejaDeMensajes = coleccionBandejaDeMensajes.Find<BsonDocument>(filter).ToList();//(bandeja => bandeja.revisor.nombre == egreso.bandejaDeMensajes.revisor.nombre).ToList();

            String listado = bandejaDeMensajes[0]["mensajes"].ToString();

            Console.WriteLine(listado);
        }

        /*public static void agregarLogABitacora()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("mydb");

            GeneradorDeLogs.agregarLogABitacora($"Se ha creado un proyecto de financiamiento de id:{nuevo.id}");

            actualizarBitacoraNoSQL(database, GeneradorDeLogs.bitacora.ID);
        }*/

    }
}

using MongoDB.Bson.Serialization;
//using MongoDB.Driver;
using System;
using TP_Anual.Egresos;
using TP_Anual.Administrador_Inicio_Sesion;
//using Quartz;
using TP_Anual.Organizaciones;
using System.Linq;
using TP_Anual.APImercadolibre;
using System.Collections.Generic;
using TP_Anual.DAOs;

namespace TP_Anual
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new BaseDeDatos())
            //{

            //    Item item1 = new Item();
            //    item1.descripcion = "Galaxy 8";
            //    //context.items.Add(item1);
            //    //context.SaveChanges();
            //    ItemDAO.getInstancia().AddItem(item1);

            //    Item item2 = new Item();
            //    item2.descripcion = "Galaxy 9";
            //    //context.items.Add(item2);
            //    //context.SaveChanges();
            //    ItemDAO.getInstancia().AddItem(item2);


            //    Egreso egreso = new Egreso();
            //    egreso.fecha = DateTime.Today;
            //    egreso.cantPresupuestos = 2;
            //    //context.egresos.Add(egreso);
            //    ////context.SaveChanges();
            //    egreso = EgresoDAO.getInstancia().Add(egreso);

            //    ItemPorEgreso itemPresupuesto1 = new ItemPorEgreso();
            //    itemPresupuesto1.item = item1;
            //    itemPresupuesto1.valor = 1000;
            //    //context.items_por_egreso.Add(itemPresupuesto1);
            //    ItemDAO.getInstancia().AddItemPorEgreso(itemPresupuesto1);

            //    ItemPorEgreso itemPresupuesto2 = new ItemPorEgreso();
            //    itemPresupuesto2.item = item2;
            //    itemPresupuesto2.valor = 2000;
            //    //context.items_por_egreso.Add(itemPresupuesto1);
            //    ItemDAO.getInstancia().AddItemPorEgreso(itemPresupuesto2);

            //    egreso.items.Add(itemPresupuesto1);
            //    egreso.items.Add(itemPresupuesto2);
            //    context.SaveChanges();

            // }


            //using (var context = new BaseDeDatos())
            //{
            //    var user = UsuarioDAO.getInstancia().getUsuarioByUserName("yo");

            //    Egreso nuevo = new Egreso();
            //    nuevo.cantPresupuestos = 1;
            //    nuevo.fecha = DateTime.Today;
            //    nuevo.bandejaDeMensajes = new BandejaDeMensajes(user);

            //    //nuevo = EgresoDAO.getInstancia().Add(nuevo);
            //    context.egresos.Add(nuevo);

            //    try
            //    {
            //        var items = "a1,a2,a3".Split(',');
            //        var cantidades = "1,2,3".Split(',');

            //        for (int i = 0; i < items.Length; i++)
            //        {
            //            //var item = ItemDAO.getInstancia().getItemByDescripcion(items[i]);
            //            Item item = new Item();
            //            item.descripcion = items[i];
            //            context.items.Add(item);
            //            context.SaveChanges();

            //            //ItemDAO.getInstancia().AddItemPorEgreso(ie);
            //            ItemPorEgreso ie = new ItemPorEgreso();
            //            ie.item = item;
            //            ie.cantidad = Int32.Parse(cantidades[i]);
            //            context.items_por_egreso.Add(ie);
            //            context.SaveChanges();

            //            nuevo.items.Add(ie);
            //            context.SaveChanges();

            //        }

            //    }
            //    catch (NullReferenceException) { }
            //}
            Console.WriteLine("fin");
            Console.ReadLine();

                //    #region Falso Test
                //    //BsonClassMap.RegisterClassMap<BandejaDeMensajes>();
                //    //BsonClassMap.RegisterClassMap<Log>();

                //    //var client = new MongoClient("mongodb://localhost:27017");
                //    //var database = client.GetDatabase("mydb");

                //    using (var context = new BaseDeDatos())
                //    {

                //        EntidadJuridica entidad_juridica = new EntidadJuridica();
                //        entidad_juridica.razon_social = "ManuMati";
                //        entidad_juridica.nombreFicticio = "ManuMati";
                //        entidad_juridica.actividad = "Servicios";
                //        entidad_juridica.comisionista = 'N';
                //        entidad_juridica.promedioVentasAnuales = 50000000;
                //        entidad_juridica.cantidadPersonal = 30;
                //        entidad_juridica.tipo = "Empresa";
                //        entidad_juridica.AsignarTipoOrganizacion();
                //        context.entidades_juridicas.Add(entidad_juridica);
                //        context.SaveChanges();

                //        EntidadBase entidad_base = new EntidadBase();
                //        entidad_base.nombreFicticio = "Seguridad";
                //        entidad_base.actividad = "Servicios";
                //        entidad_base.comisionista = 'N';
                //        entidad_base.promedioVentasAnuales = 100000;
                //        entidad_base.cantidadPersonal = 3;
                //        entidad_base.tipo = "Empresa";
                //        entidad_base.AsignarTipoOrganizacion();
                //        context.entidades_base.Add(entidad_base);
                //        context.SaveChanges();

                //        entidad_juridica.entidades_base.Add(entidad_base);
                //        context.SaveChanges();

                //        //var hola = context.presupuestos.Single(p => p.id_presupuesto == 1);
                //        //Console.WriteLine($"{hola.documentoComercial.id_documento}");

                //        /*var presupuesto = context.presupuestos.Single(p => p.id_presupuesto == 1);

                //        Console.WriteLine($"{presupuesto.egreso.cantPresupuestos}");
                //        foreach(Item i in presupuesto.itemsDePresupuesto)
                //        {
                //            Console.WriteLine($"{i.descripcion}");
                //        }*/
                //        //ApimercadoLibre api = new ApimercadoLibre();
                //        /*api.obtenerProvincias();
                //        api.paises();
                //        api.ciudades();
                //        api.monedas();*/
                //        Organizacion organizacion = new Organizacion();

                //        Ingreso ingreso = new Ingreso();
                //        ingreso.descripcion = "pepe";
                //        ingreso.total = 5000;
                //        context.ingresos.Add(ingreso);
                //        context.SaveChanges();

                //        Proveedor proveedor1 = new Proveedor();
                //        proveedor1.CUIT = "203050065";
                //        proveedor1.razon_social = "proveedor";
                //        context.proveedores.Add(proveedor1);
                //        context.SaveChanges();

                //        Item item1 = new Item();
                //        item1.descripcion = "Galaxy 8";
                //        context.items.Add(item1);
                //        context.SaveChanges();

                //        Item item2 = new Item();
                //        item2.descripcion = "Galaxy 9";
                //        context.items.Add(item2);
                //        context.SaveChanges();

                //        Criterio crit = new Criterio();
                //        crit.descripcion = "soy un criterio";
                //        context.criterios.Add(crit);
                //        context.SaveChanges();

                //        Categoria categoria1 = new Categoria();
                //        categoria1.descripcion = "Precio cuidado";
                //        categoria1.criterio = crit;
                //        context.categorias.Add(categoria1);
                //        context.SaveChanges();


                //        Categoria categoria2 = new Categoria();
                //        categoria2.descripcion = "Precio no cuidado";
                //        categoria2.criterio = crit;
                //        context.categorias.Add(categoria2);
                //        context.SaveChanges();


                //        CriterioPorItem ci = new CriterioPorItem();
                //        ci.criterio = crit;
                //        ci.categoria_item = categoria1;
                //        item1.criteriosDeItem.Add(ci);
                //        context.criterios_por_item.Add(ci);
                //        context.SaveChanges();


                //        DocumentoComercial doc = new DocumentoComercial();
                //        doc.tipo = "ticket";
                //        doc.numero = 1;
                //        context.documentos.Add(doc);
                //        context.SaveChanges();

                //        Egreso egreso = new Egreso();
                //        egreso.fecha = DateTime.Today;
                //        egreso.cantPresupuestos = 2;
                //        //egreso.documentoComercial = doc;
                //        egreso.proveedorElegido = proveedor1;
                //        context.egresos.Add(egreso);
                //        context.SaveChanges();

                //        Presupuesto presupuesto1 = new Presupuesto();
                //        presupuesto1.egreso = egreso;
                //        presupuesto1.proveedor = proveedor1;
                //        presupuesto1.documentoComercial = doc;
                //        context.presupuestos.Add(presupuesto1);
                //        context.SaveChanges();

                //        ItemPorPresupuesto itemPresupuesto1 = new ItemPorPresupuesto();
                //        itemPresupuesto1.item = item1;
                //        itemPresupuesto1.valor = 1000;
                //        context.items_por_presupuesto.Add(itemPresupuesto1);

                //        ItemPorPresupuesto itemPresupuesto2 = new ItemPorPresupuesto();
                //        itemPresupuesto2.item = item2;
                //        itemPresupuesto2.valor = 2000;
                //        context.items_por_presupuesto.Add(itemPresupuesto1);

                //        presupuesto1.agregar_item(itemPresupuesto1);
                //        presupuesto1.agregar_item(itemPresupuesto2);
                //        context.SaveChanges();

                //        egreso.presupuestos.Add(presupuesto1);
                //        context.SaveChanges();


                //        ingreso = context.ingresos.Single(i => i.id_ingreso == 1);

                //        ingreso.egresos.Add(egreso);
                //        context.SaveChanges();

                //        MedioDePago medio_de_pago = new MedioDePago();
                //        medio_de_pago.nombre = "tarjeta";
                //        medio_de_pago.tipoDePago = "debito";

                //        egreso.medioDePago = medio_de_pago;
                //        //egreso.bandejaDeMensajes = new BandejaDeMensajes("Grupo 5");
                //        //registrarBandejaDeMensajes(database, new Usuario("Grupo 5", "1234", true), egreso);
                //        egreso.criterioDeSeleccion = new MenorValor();

                //        proveedor1.razon_social = "razon1";
                //        Proveedor proveedor2 = new Proveedor();
                //        //proveedor2.CUIT = 20305006502;
                //        proveedor2.razon_social = "razon2";

                //        Item item3 = new Item();
                //        item3.descripcion = "Galaxy 10";
                //        context.items.Add(item3);
                //        Item item4 = new Item();
                //        item4.descripcion = "Galaxy 10 Plus";
                //        context.items.Add(item4);
                //        context.SaveChanges();

                //        presupuesto1.proveedor = proveedor1;

                //        Presupuesto presupuesto2 = new Presupuesto();
                //        //presupuesto2.documentoComercial =doc;
                //        presupuesto2.proveedor = proveedor2;
                //        context.presupuestos.Add(presupuesto2);
                //        context.SaveChanges();

                //        ItemPorPresupuesto itemPorPresupuesto3 = new ItemPorPresupuesto();
                //        itemPorPresupuesto3.item = item3;
                //        itemPorPresupuesto3.valor = 3000;
                //        ItemPorPresupuesto itemPorPresupuesto4 = new ItemPorPresupuesto();
                //        itemPorPresupuesto4.item = item4;
                //        itemPorPresupuesto4.valor = 4000;
                //        context.items_por_presupuesto.Add(itemPorPresupuesto3);
                //        context.items_por_presupuesto.Add(itemPorPresupuesto4);
                //        context.SaveChanges();

                //        presupuesto2.agregar_item(itemPorPresupuesto3);
                //        presupuesto2.agregar_item(itemPorPresupuesto4);
                //        context.SaveChanges();

                //        egreso.presupuestos.Add(presupuesto2);
                //        egreso.elegirPresupuesto(presupuesto1);

                //        var presupuesto = context.presupuestos
                //        .Include("itemsDePresupuesto")
                //        .Include("egreso").Single(p => p.id_presupuesto == 1);

                //        /*
                //        Console.WriteLine($"{presupuesto.egreso.cantPresupuestos}");
                //        foreach (ItemPorPresupuesto i in presupuesto.itemsDePresupuesto)
                //        {
                //            Console.WriteLine($"{i.item.descripcion}");
                //        }
                //        */


                //        //EGRESOS DE PRUEBA PARA VINCULACION-----------------------------------

                //        Egreso egresoPrueba1 = new Egreso();
                //        egresoPrueba1.valorTotal = 126312;
                //        egresoPrueba1.descripcion = "egreso 1";
                //        organizacion.egresosPrueba.Add(egresoPrueba1);

                //        Egreso egresoPrueba2 = new Egreso();
                //        egresoPrueba2.valorTotal = 1263;
                //        egresoPrueba2.descripcion = "egreso 2";
                //        organizacion.egresosPrueba.Add(egresoPrueba2);

                //        Egreso egresoPrueba3 = new Egreso();
                //        egresoPrueba3.valorTotal = 4365;
                //        egresoPrueba3.descripcion = "egreso 3";
                //        organizacion.egresosPrueba.Add(egresoPrueba3);

                //        Egreso egresoPrueba4 = new Egreso();
                //        egresoPrueba4.valorTotal = 126;
                //        egresoPrueba4.descripcion = "egreso 4";
                //        organizacion.egresosPrueba.Add(egresoPrueba4);

                //        Egreso egresoPrueba5 = new Egreso();
                //        egresoPrueba5.valorTotal = 1248;
                //        egresoPrueba5.descripcion = "egreso 5";
                //        organizacion.egresosPrueba.Add(egresoPrueba5);

                //        Egreso egresoPrueba6 = new Egreso();
                //        egresoPrueba6.valorTotal = 12687;
                //        egresoPrueba6.descripcion = "egreso 6";
                //        organizacion.egresosPrueba.Add(egresoPrueba6);

                //        Egreso egresoPrueba7 = new Egreso();
                //        egresoPrueba7.valorTotal = 16348;
                //        egresoPrueba7.descripcion = "egreso 7";
                //        organizacion.egresosPrueba.Add(egresoPrueba7);

                //        Egreso egresoPrueba8 = new Egreso();
                //        egresoPrueba8.valorTotal = 1267;
                //        egresoPrueba8.descripcion = "egreso 8";
                //        organizacion.egresosPrueba.Add(egresoPrueba8);

                //        Egreso egresoPrueba9 = new Egreso();
                //        egresoPrueba9.valorTotal = 13;
                //        egresoPrueba9.descripcion = "egreso 9";
                //        egresoPrueba9.fecha = new DateTime(2020, 1, 4, 0, 0, 0);
                //        organizacion.egresosPrueba.Add(egresoPrueba9);

                //        Egreso egresoPrueba10 = new Egreso();
                //        egresoPrueba10.valorTotal = 48;
                //        egresoPrueba10.descripcion = "egreso 10";
                //        organizacion.egresosPrueba.Add(egresoPrueba10);

                //        //INGRESOS DE PRUEBA PARA VINCULACION-------------------------------

                //        Ingreso ingresoPrueba1 = new Ingreso();
                //        ingresoPrueba1.total = 7842;
                //        ingresoPrueba1.descripcion = "ingreso 1";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba1);

                //        Ingreso ingresoPrueba2 = new Ingreso();
                //        ingresoPrueba2.total = 23734;
                //        ingresoPrueba2.descripcion = "ingreso 2";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba2);

                //        Ingreso ingresoPrueba3 = new Ingreso();
                //        ingresoPrueba3.total = 127623;
                //        ingresoPrueba3.descripcion = "ingreso 3";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba3);

                //        Ingreso ingresoPrueba4 = new Ingreso();
                //        ingresoPrueba4.total = 1273;
                //        ingresoPrueba4.descripcion = "ingreso 4";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba4);

                //        Ingreso ingresoPrueba5 = new Ingreso();
                //        ingresoPrueba5.total = 12673;
                //        ingresoPrueba5.descripcion = "ingreso 5";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba5);

                //        Ingreso ingresoPrueba6 = new Ingreso();
                //        ingresoPrueba6.total = 27;
                //        ingresoPrueba6.descripcion = "ingreso 6";
                //        ingresoPrueba6.fecha = new DateTime(2020, 1, 15, 0, 0, 0);
                //        organizacion.ingresosPrueba.Add(ingresoPrueba6);

                //        Ingreso ingresoPrueba7 = new Ingreso();
                //        ingresoPrueba7.total = 1632;
                //        ingresoPrueba7.descripcion = "ingreso 7";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba7);

                //        Ingreso ingresoPrueba8 = new Ingreso();
                //        ingresoPrueba8.total = 1554;
                //        ingresoPrueba8.descripcion = "ingreso 8";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba8);

                //        Ingreso ingresoPrueba9 = new Ingreso();
                //        ingresoPrueba9.total = 16327;
                //        ingresoPrueba9.descripcion = "ingreso 9";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba9);

                //        Ingreso ingresoPrueba10 = new Ingreso();
                //        ingresoPrueba10.total = 1563;
                //        ingresoPrueba10.descripcion = "ingreso 10";
                //        organizacion.ingresosPrueba.Add(ingresoPrueba10);



                //        InterfazInicioDeSesion interfaz = new InterfazInicioDeSesion();
                //        string usuarioActual;

                //        Console.WriteLine("Ingresar usuario: ");
                //        usuarioActual = Console.ReadLine();

                //        while (true)
                //        {
                //            Console.WriteLine("1. Validar Compra // 2. Ver validacion // 3.Vincular ingresos con egresos // 4. Fin");
                //            var eleccion = Console.ReadLine();

                //            if (eleccion == "1")
                //            {
                //                ValidadorDeEgreso.egresoValido(egreso);
                //                //actualizarBaseDeDatosNoSQL(database, egreso);
                //            }
                //            if (eleccion == "2")
                //            {
                //                egreso.bandejaDeMensajes.mostrarMensajes(usuarioActual);
                //                //actualizarBaseDeDatosNoSQL(database, egreso);
                //            }
                //            if(eleccion == "3")
                //                organizacion.vincular();

                //            if (eleccion == "4")
                //                break;

                //        }

                //    }


                //    /*
                //    void jobValidadorEgreso(Scheduler sched)
                //    {
                //        JobDataMap jobData = new JobDataMap();
                //        jobData.Add("egreso", egreso);

                //        IJobDetail jobValidadorEgreso = JobBuilder.Create<JobValidadorEgresos>()
                //            .WithIdentity("trabajoValidacionEgreso", "grupoValidacionEgreso")
                //            .UsingJobData(jobData)
                //            .Build();

                //        ITrigger triggerValidadorEgreso = TriggerBuilder.Create()
                //            .WithIdentity("tiempoValidacionEgreso", "grupoValidacionEgreso")
                //            .StartNow()
                //            .WithSimpleSchedule(x => x
                //            .WithIntervalInSeconds(10)
                //            .RepeatForever())
                //            .Build();

                //        sched.agregarTarea(jobValidadorEgreso, triggerValidadorEgreso);


                //    }

                //    */
                //    //Console.WriteLine(egreso.valorTotal);

                //    //BandejaDeMensajes.mostrarMensajes();

                //    //usuarioActual = interfaz.inicioDeSesion();
                //    //Console.WriteLine(usuarioActual);
                //    //con ese usuario, el validador se fija si es el usuario que puede ver la compra

                //}

                ///*
                //public static void actualizarBaseDeDatosNoSQL(IMongoDatabase database, Egreso egreso)
                //{
                //    // Construyo filtro de busqueda
                //    var builder = Builders<BandejaDeMensajes>.Filter;
                //    var filter = builder.Where(bandeja => bandeja.revisor == egreso.bandejaDeMensajes.revisor);

                //    // Traigo la coleccion
                //    var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");

                //    // Busco usando el filtro y convierto los resultados a lista
                //    var bandejasDeMensajesEncontradas = coleccionBandejaDeMensajes.Find<BandejaDeMensajes>(filter);
                //    var listaBandejaDeMensajes = bandejasDeMensajesEncontradas.ToList<BandejaDeMensajes>();
                //    var bandejaDeMensajes = listaBandejaDeMensajes[0];
                //    egreso.bandejaDeMensajes.ID = bandejaDeMensajes.ID;

                //    // Creo una bandeja de mensajes y la inserto
                //    coleccionBandejaDeMensajes.ReplaceOne(filter, egreso.bandejaDeMensajes);
                //}
                //*/
                ///*
                //public static void registrarBandejaDeMensajes(IMongoDatabase database, Usuario revisor, Egreso egreso)
                //{
                //    // Agrego bandeja de mensajes a egreso
                //    egreso.bandejaDeMensajes = new BandejaDeMensajes(revisor);

                //    // Traigo la coleccion
                //    var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");

                //    // Creo una bandeja de mensajes y la inserto
                //    var bandejaDeMensajes = new BandejaDeMensajes(revisor);
                //    coleccionBandejaDeMensajes.InsertOne(bandejaDeMensajes);
                //}
                //*/
                ///*  public static void mostrarBandejaDeMensajesDeEgreso(IMongoDatabase database, Egreso egreso)
                //  {
                //     // var builder = Builders<BandejaDeMensajes>.Filter;
                //     // var filter = builder.Where(bandeja => bandeja.ID == egreso.bandejaDeMensajes.ID);
                //    //  var filter = builder.Where(bandeja => bandeja.revisor == egreso.bandejaDeMensajes.revisor);

                //      var coleccionBandejaDeMensajes = database.GetCollection<BandejaDeMensajes>("coleccionBandejaDeMensajes");
                //     //  var bandejasDeMensajesEncontradas = coleccionBandejaDeMensajes.Find<BandejaDeMensajes>(filter);
                //     // var listaBandejaDeMensajes = bandejasDeMensajesEncontradas.ToList<BandejaDeMensajes>();
                //      var bandejaDeMensajes = coleccionBandejaDeMensajes.Find<BandejaDeMensajes>(bandeja => bandeja.revisor == egreso.bandejaDeMensajes.revisor);
                //     // var bandejaDeMensajes = coleccionBandejaDeMensajes.Find<BandejaDeMensajes>(bandeja => bandeja.revisor == egreso.bandejaDeMensajes.revisor);
                //      // var bandejaDeMensajes = coleccionBandejaDeMensajes.find();

                //      Console.WriteLine(bandejaDeMensajes);
                //  */
                //#endregion
        }
    }
}

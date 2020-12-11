using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TP_Anual.Egresos;
using TP_Anual.Organizaciones;
using TP_Anual.Administrador_Inicio_Sesion;

namespace Test
{
    [TestClass]

    //-----------TEST MySql

    public class TestMySql
    {
        public void TestMethod1()
        {
            MySql context = new MySql();

            EntidadJuridica entidad_juridica = new EntidadJuridica();

            entidad_juridica.razon_social = "ManuMati";
            entidad_juridica.nombreFicticio = "ManuMati";
            entidad_juridica.actividad = "Servicios";
            entidad_juridica.comisionista = 'N';
            entidad_juridica.promedioVentasAnuales = 50000000;
            entidad_juridica.cantidadPersonal = 30;
            entidad_juridica.tipo = "Empresa";

            entidad_juridica.AsignarTipoOrganizacion();
            context.entidades_juridicas.Add(entidad_juridica);
            context.SaveChanges();
            
            
            EntidadBase entidad_base = new EntidadBase();
            entidad_base.nombreFicticio = "Seguridad";
            entidad_base.actividad = "Servicios";
            entidad_base.comisionista = 'N';
            entidad_base.promedioVentasAnuales = 100000;
            entidad_base.cantidadPersonal = 3;
            entidad_base.tipo = "Empresa";
            //entidad_base.AsignarTipoOrganizacion();
            //context.entidades_base.Add(entidad_base);
            //context.SaveChanges();

            entidad_juridica.entidades_base.Add(entidad_base);
            //context.SaveChanges();

            //var hola = context.presupuestos.Single(p => p.id_presupuesto == 1);
            //Console.WriteLine($"{hola.documentoComercial.id_documento}");

            var presupuesto = context.presupuestos.Single(p => p.id_presupuesto == 1);

            foreach(Item i in presupuesto.itemsDePresupuesto)
            {
            Console.WriteLine($"{i.descripcion}");
            }

            Organizacion organizacion = new Organizacion();

            Ingreso ingreso = new Ingreso();
            ingreso.descripcion = "pepe";
            ingreso.total = 5000;
            //context.ingresos.Add(ingreso);
            //context.SaveChanges();

            Proveedor proveedor1 = new Proveedor();
            proveedor1.CUIT = "203050065";
            proveedor1.razon_social = "proveedor";
            //context.proveedores.Add(proveedor1);
            //context.SaveChanges();

            Item item1 = new Item();
            item1.descripcion = "Galaxy 8";
            //context.items.Add(item1);
            //context.SaveChanges();

            Item item2 = new Item();
            item2.descripcion = "Galaxy 9";
            //context.items.Add(item2);
            //context.SaveChanges();

            Criterio crit = new Criterio();
            crit.descripcion = "soy un criterio";
            //context.criterios.Add(crit);
            //context.SaveChanges();

            Categoria categoria1 = new Categoria();
            categoria1.descripcion = "Precio cuidado";
            categoria1.criterio = crit;
            //context.categorias.Add(categoria1);
            //context.SaveChanges();


            Categoria categoria2 = new Categoria();
            categoria2.descripcion = "Precio no cuidado";
            categoria2.criterio = crit;
            //context.categorias.Add(categoria2);
            //context.SaveChanges();


            CriterioPorItem ci = new CriterioPorItem();
            ci.criterio = crit;
            ci.categoria_item = categoria1;
            item1.criteriosDeItem.Add(ci);
            //context.criterios_por_item.Add(ci);
            //context.SaveChanges();


            DocumentoComercial doc = new DocumentoComercial();
            doc.tipo = "ticket";
            doc.numero = 1;
            //context.documentos.Add(doc);
            //context.SaveChanges();

            Egreso egreso = new Egreso();
            egreso.fecha = DateTime.Today;
            egreso.cantPresupuestos = 2;
            //egreso.documentoComercial = doc;
            egreso.proveedorElegido = proveedor1;
            //context.egresos.Add(egreso);
            //context.SaveChanges();

            Presupuesto presupuesto1 = new Presupuesto();
            presupuesto1.egreso = egreso;
            presupuesto1.proveedor = proveedor1;
            presupuesto1.documentoComercial = doc;
            //context.presupuestos.Add(presupuesto1);
            //context.SaveChanges();

            ItemPorPresupuesto itemPresupuesto1 = new ItemPorPresupuesto();
            itemPresupuesto1.item = item1;
            itemPresupuesto1.valor = 1000;
            //context.items_por_presupuesto.Add(itemPresupuesto1);

            ItemPorPresupuesto itemPresupuesto2 = new ItemPorPresupuesto();
            itemPresupuesto2.item = item2;
            itemPresupuesto2.valor = 2000;
            //context.items_por_presupuesto.Add(itemPresupuesto1);

            presupuesto1.agregar_item(itemPresupuesto1);
            presupuesto1.agregar_item(itemPresupuesto2);
            //context.SaveChanges();

            egreso.presupuestos.Add(presupuesto1);
            //context.SaveChanges();


            //ingreso = context.ingresos.Single(i => i.id_ingreso == 1);

            ingreso.egresos.Add(egreso);
            //context.SaveChanges();

            MedioDePago medio_de_pago = new MedioDePago();
            medio_de_pago.nombre = "tarjeta";
            medio_de_pago.tipoDePago = "debito";

            egreso.medioDePago = medio_de_pago;
            //egreso.bandejaDeMensajes = new BandejaDeMensajes("Grupo 5");
            var revisor = new Usuario("Grupo 5", "pepe", false);
            //registrarBandejaDeMensajes(database, revisor, egreso);
            //egreso.criterioDeSeleccion = new MenorValor();

            proveedor1.razon_social = "razon1";
            Proveedor proveedor2 = new Proveedor();
            //proveedor2.CUIT = 20305006502;
            proveedor2.razon_social = "razon2";

            Item item3 = new Item();
            item3.descripcion = "Galaxy 10";
            //context.items.Add(item3);
            Item item4 = new Item();
            item4.descripcion = "Galaxy 10 Plus";
            //context.items.Add(item4);
            //context.SaveChanges();

            presupuesto1.proveedor = proveedor1;

            Presupuesto presupuesto2 = new Presupuesto();
            //presupuesto2.documentoComercial =doc;
            presupuesto2.proveedor = proveedor2;
            //context.presupuestos.Add(presupuesto2);
            //context.SaveChanges();

            ItemPorPresupuesto itemPorPresupuesto3 = new ItemPorPresupuesto();
            itemPorPresupuesto3.item = item3;
            itemPorPresupuesto3.valor = 3000;
            ItemPorPresupuesto itemPorPresupuesto4 = new ItemPorPresupuesto();
            itemPorPresupuesto4.item = item4;
            itemPorPresupuesto4.valor = 4000;
            //context.items_por_presupuesto.Add(itemPorPresupuesto3);
            //context.items_por_presupuesto.Add(itemPorPresupuesto4);
            //context.SaveChanges();

            presupuesto2.agregar_item(itemPorPresupuesto3);
            presupuesto2.agregar_item(itemPorPresupuesto4);
            //context.SaveChanges();

            egreso.presupuestos.Add(presupuesto2);
            egreso.elegirPresupuesto(presupuesto1);

    
        }

    }

    //-----------TEST Vinculacion

    public class Vinculacion
    {
        [TestMethod]
        public void TestMethod1()
        {

            Organizacion organizacion = new Organizacion();

            //------------EGRESOS
            Egreso egresoPrueba1 = new Egreso();
            egresoPrueba1.valorTotal = 126312;
            egresoPrueba1.descripcion = "egreso 1";
            organizacion.egresos.Add(egresoPrueba1);

            Egreso egresoPrueba2 = new Egreso();
            egresoPrueba2.valorTotal = 1263;
            egresoPrueba2.descripcion = "egreso 2";
            organizacion.egresos.Add(egresoPrueba2);

            Egreso egresoPrueba3 = new Egreso();
            egresoPrueba3.valorTotal = 4365;
            egresoPrueba3.descripcion = "egreso 3";
            organizacion.egresos.Add(egresoPrueba3);

            Egreso egresoPrueba4 = new Egreso();
            egresoPrueba4.valorTotal = 126;
            egresoPrueba4.descripcion = "egreso 4";
            organizacion.egresos.Add(egresoPrueba4);

            Egreso egresoPrueba5 = new Egreso();
            egresoPrueba5.valorTotal = 1248;
            egresoPrueba5.descripcion = "egreso 5";
            organizacion.egresos.Add(egresoPrueba5);

            Egreso egresoPrueba6 = new Egreso();
            egresoPrueba6.valorTotal = 12687;
            egresoPrueba6.descripcion = "egreso 6";
            organizacion.egresos.Add(egresoPrueba6);

            Egreso egresoPrueba7 = new Egreso();
            egresoPrueba7.valorTotal = 16348;
            egresoPrueba7.descripcion = "egreso 7";
            organizacion.egresos.Add(egresoPrueba7);

            Egreso egresoPrueba8 = new Egreso();
            egresoPrueba8.valorTotal = 1267;
            egresoPrueba8.descripcion = "egreso 8";
            organizacion.egresos.Add(egresoPrueba8);

            Egreso egresoPrueba9 = new Egreso();
            egresoPrueba9.valorTotal = 13;
            egresoPrueba9.descripcion = "egreso 9";
            egresoPrueba9.fecha = new DateTime(2020, 1, 4, 0, 0, 0);
            organizacion.egresos.Add(egresoPrueba9);

            Egreso egresoPrueba10 = new Egreso();
            egresoPrueba10.valorTotal = 48;
            egresoPrueba10.descripcion = "egreso 10";
            organizacion.egresos.Add(egresoPrueba10);

            //------------INGRESOS

            Ingreso ingresoPrueba1 = new Ingreso();
            ingresoPrueba1.total = 7842;
            ingresoPrueba1.descripcion = "ingreso 1";
            organizacion.ingresos.Add(ingresoPrueba1);

            Ingreso ingresoPrueba2 = new Ingreso();
            ingresoPrueba2.total = 23734;
            ingresoPrueba2.descripcion = "ingreso 2";
            organizacion.ingresos.Add(ingresoPrueba2);

            Ingreso ingresoPrueba3 = new Ingreso();
            ingresoPrueba3.total = 127623;
            ingresoPrueba3.descripcion = "ingreso 3";
            organizacion.ingresos.Add(ingresoPrueba3);

            Ingreso ingresoPrueba4 = new Ingreso();
            ingresoPrueba4.total = 1273;
            ingresoPrueba4.descripcion = "ingreso 4";
            organizacion.ingresos.Add(ingresoPrueba4);

            Ingreso ingresoPrueba5 = new Ingreso();
            ingresoPrueba5.total = 12673;
            ingresoPrueba5.descripcion = "ingreso 5";
            organizacion.ingresos.Add(ingresoPrueba5);

            Ingreso ingresoPrueba6 = new Ingreso();
            ingresoPrueba6.total = 27;
            ingresoPrueba6.descripcion = "ingreso 6";
            ingresoPrueba6.fecha = new DateTime(2020, 1, 15, 0, 0, 0);
            organizacion.ingresos.Add(ingresoPrueba6);

            Ingreso ingresoPrueba7 = new Ingreso();
            ingresoPrueba7.total = 1632;
            ingresoPrueba7.descripcion = "ingreso 7";
            organizacion.ingresos.Add(ingresoPrueba7);

            Ingreso ingresoPrueba8 = new Ingreso();
            ingresoPrueba8.total = 1554;
            ingresoPrueba8.descripcion = "ingreso 8";
            organizacion.ingresos.Add(ingresoPrueba8);

            Ingreso ingresoPrueba9 = new Ingreso();
            ingresoPrueba9.total = 16327;
            ingresoPrueba9.descripcion = "ingreso 9";
            organizacion.ingresos.Add(ingresoPrueba9);

            Ingreso ingresoPrueba10 = new Ingreso();
            ingresoPrueba10.total = 1563;
            ingresoPrueba10.descripcion = "ingreso 10";
            organizacion.ingresos.Add(ingresoPrueba10);


            //  Assert.AreEqual(Expected, result);

        }
    }


    //-----------TEST ProyectoDeFinanciamiento
    public class ProyectosDeFinanciamientos
    {
        public void TestMethod1()
        {
            Usuario usuario = new Usuario("pepe", "dds2020", false);

            ProyectoDeFinanciamiento proyecto1 = new ProyectoDeFinanciamiento(15, 12000, usuario);
            //registrarbitacoradeoperaciones(database);
            //egreso.proyecto = proyecto1;

            //proyecto1.agregaringreso(ingresoprueba8);
            ////actualizarbitacoranosql(database, generadordelogs.bitacora.id);

            //proyecto1.agregaringreso(ingresoprueba9);
            ////actualizarbitacoranosql(database, generadordelogs.bitacora.id);

            //proyecto1.cerrarproyecto();
        }

    }
}


/*
           var usuario = new Usuario("pepe", "dds2020", false);

           ApimercadoLibre api = new ApimercadoLibre();
           api.obtenerProvincias();
           api.paises();
           api.ciudades();
           api.monedas();

           console.writeline("ingresar usuario: ");
           usuarioactual = console.readline();

           while (true)
           {
               console.writeline("1. validar compra // 2. ver validacion // 3.vincular ingresos con egresos // 4. fin");
               var eleccion = console.readline();

               if (eleccion == "1")
               {
                   validadordeegreso.egresovalido(egreso);
                   //actualizarbasededatosnosql(database, egreso);
               }
               if (eleccion == "2")
               {
                   egreso.bandejademensajes.mostrarmensajes(usuarioactual);
                   //actualizarbasededatosnosql(database, egreso);
                   //mostrarbandejademensajesdeegreso(database, egreso);
               }
               if (eleccion == "3")
                   organizacion.vincular();

               if (eleccion == "4")
                   break;

           }

       }

       console.writeline(egreso.valortotal);

       bandejademensajes.mostrarmensajes();

       usuarioactual = interfaz.iniciodesesion();
       console.writeline(usuarioactual);
       con ese usuario, el validador se fija si es el usuario que puede ver la compra

   }

   void jobvalidadoregreso(scheduler sched, egreso egreso)
   {

       jobdatamap jobdata = new jobdatamap();
       jobdata.add("egreso", egreso);

       ijobdetail jobvalidadoregresos = jobbuilder.create<jobvalidadoregresos>()
           .withidentity("trabajovalidacionegreso", "grupovalidacionegreso")
           .usingjobdata(jobdata)
           .build();

       itrigger triggervalidadoregreso = triggerbuilder.create()
           .withidentity("tiempovalidacionegreso", "grupovalidacionegreso")
           .startnow()
           .withsimpleschedule(x => x
           .withintervalinseconds(10)
           .repeatforever())
           .build();

       sched.agregartarea(jobvalidadoregresos, triggervalidadoregreso);

*/
using System;
using TP_Anual.Egresos;
using TP_Anual.Administrador_Inicio_Sesion;
using Quartz;
using TP_Anual.Organizaciones;
using System.Linq;

namespace TP_Anual
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BaseDeDatos())
            {

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
                entidad_base.AsignarTipoOrganizacion();
                context.entidades_base.Add(entidad_base);
                context.SaveChanges();

                entidad_juridica.entidades_base.Add(entidad_base);
                context.SaveChanges();

                //var hola = context.presupuestos.Single(p => p.id_presupuesto == 1);
                //Console.WriteLine($"{hola.documentoComercial.id_documento}");

                /*var presupuesto = context.presupuestos.Single(p => p.id_presupuesto == 1);

                Console.WriteLine($"{presupuesto.egreso.cantPresupuestos}");
                foreach(Item i in presupuesto.itemsDePresupuesto)
                {
                    Console.WriteLine($"{i.descripcion}");
                }*/

                Ingreso ingreso = new Ingreso();
                ingreso.descripcion = "pepe";
                ingreso.total = 5000;
                context.ingresos.Add(ingreso);
                context.SaveChanges();

                Proveedor proveedor1 = new Proveedor();
                proveedor1.CUIT = 203050065;
                proveedor1.razon_social = "proveedor";
                context.proveedores.Add(proveedor1);
                context.SaveChanges();

                Item item1 = new Item();
                item1.descripcion = "Galaxy 8";
                context.items.Add(item1);
                context.SaveChanges();

                Item item2 = new Item();
                item2.descripcion = "Galaxy 9";
                context.items.Add(item2);
                context.SaveChanges();

                Criterio crit = new Criterio();
                crit.descripcion = "soy un criterio";
                context.criterios.Add(crit);
                
                Categoria categoria1 = new Categoria();
                categoria1.descripcion = "Precio cuidado";
                categoria1.criterio = crit;
                context.categorias.Add(categoria1);

                Categoria categoria2 = new Categoria();
                categoria2.descripcion = "Precio no cuidado";
                categoria2.criterio = crit;
                context.categorias.Add(categoria2);

                CriterioPorItem ci = new CriterioPorItem();
                ci.criterio = crit;
                ci.categoria_item = categoria1;
                item1.criteriosDeItem.Add(ci);
                context.criterios_por_item.Add(ci);
                context.SaveChanges();


                DocumentoComercial doc = new DocumentoComercial();
                doc.tipo = "ticket";
                doc.numero = 1;
                context.documentos.Add(doc);
                context.SaveChanges();

                Egreso egreso = new Egreso();
                egreso.fecha = DateTime.Today;
                egreso.cantPresupuestos = 2;
                //egreso.documentoComercial = doc;
                egreso.proveedorElegido = proveedor1;
                context.egresos.Add(egreso);
                context.SaveChanges();

                Presupuesto presupuesto1 = new Presupuesto();
                presupuesto1.egreso = egreso;
                presupuesto1.proveedor = proveedor1;
                presupuesto1.documentoComercial = doc;
                context.presupuestos.Add(presupuesto1);
                context.SaveChanges();

                ItemPorPresupuesto itemPresupuesto1 = new ItemPorPresupuesto();
                itemPresupuesto1.item = item1;
                itemPresupuesto1.valor = 1000;
                context.items_por_presupuesto.Add(itemPresupuesto1);

                ItemPorPresupuesto itemPresupuesto2 = new ItemPorPresupuesto();
                itemPresupuesto2.item = item2;
                itemPresupuesto2.valor = 2000;
                context.items_por_presupuesto.Add(itemPresupuesto1);

                presupuesto1.agregar_item(itemPresupuesto1);
                presupuesto1.agregar_item(itemPresupuesto2);
                context.SaveChanges();

                egreso.presupuestos.Add(presupuesto1);
                context.SaveChanges();


                ingreso = context.ingresos.Single(i => i.id_ingreso == 1);

                ingreso.egresos.Add(egreso);
                context.SaveChanges();

                MedioDePago medio_de_pago = new MedioDePago();
                medio_de_pago.nombre = "tarjeta";
                medio_de_pago.tipoDePago = "debito";

                egreso.medioDePago = medio_de_pago;
                egreso.bandejaDeMensajes = new BandejaDeMensajes("Grupo 5");
                egreso.criterioDeSeleccion = new MenorValor();

                proveedor1.razon_social = "razon1";
                Proveedor proveedor2 = new Proveedor();
                //proveedor2.CUIT = 20305006502;
                proveedor2.razon_social = "razon2";

                Item item3 = new Item();
                item3.descripcion = "Galaxy 10";
                context.items.Add(item3);
                Item item4 = new Item();
                item4.descripcion = "Galaxy 10 Plus";
                context.items.Add(item4);
                context.SaveChanges();
                
                presupuesto1.proveedor = proveedor1;
                
                Presupuesto presupuesto2 = new Presupuesto();
                //presupuesto2.documentoComercial =doc;
                presupuesto2.proveedor = proveedor2;
                context.presupuestos.Add(presupuesto2);
                context.SaveChanges();

                ItemPorPresupuesto itemPorPresupuesto3 = new ItemPorPresupuesto();
                itemPorPresupuesto3.item = item3;
                itemPorPresupuesto3.valor = 3000;
                ItemPorPresupuesto itemPorPresupuesto4 = new ItemPorPresupuesto();
                itemPorPresupuesto4.item = item4;
                itemPorPresupuesto4.valor = 4000;
                context.items_por_presupuesto.Add(itemPorPresupuesto3);
                context.items_por_presupuesto.Add(itemPorPresupuesto4);
                context.SaveChanges();

                presupuesto2.agregar_item(itemPorPresupuesto3);
                presupuesto2.agregar_item(itemPorPresupuesto4);
                context.SaveChanges();

                egreso.presupuestos.Add(presupuesto2);
                egreso.elegirPresupuesto(presupuesto1);



                InterfazInicioDeSesion interfaz = new InterfazInicioDeSesion();
                string usuarioActual;

                Console.WriteLine("Ingresar usuario: ");
                usuarioActual = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine("1. Validar Compra // 2. Ver validacion // 3. Fin");
                    var eleccion = Console.ReadLine();

                    if (eleccion == "1")
                        ValidadorDeEgreso.egresoValido(egreso);

                    if (eleccion == "2")
                        egreso.bandejaDeMensajes.mostrarMensajes(usuarioActual);

                    if (eleccion == "3")
                        break;

                }

            }
            

            /*
            void jobValidadorEgreso(Scheduler sched)
            {
                JobDataMap jobData = new JobDataMap();
                jobData.Add("egreso", egreso);

                IJobDetail jobValidadorEgreso = JobBuilder.Create<JobValidadorEgresos>()
                    .WithIdentity("trabajoValidacionEgreso", "grupoValidacionEgreso")
                    .UsingJobData(jobData)
                    .Build();

                ITrigger triggerValidadorEgreso = TriggerBuilder.Create()
                    .WithIdentity("tiempoValidacionEgreso", "grupoValidacionEgreso")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                    .Build();

                sched.agregarTarea(jobValidadorEgreso, triggerValidadorEgreso);


            }

            */
            //Console.WriteLine(egreso.valorTotal);

            //BandejaDeMensajes.mostrarMensajes();

            //usuarioActual = interfaz.inicioDeSesion();
            //Console.WriteLine(usuarioActual);
            //con ese usuario, el validador se fija si es el usuario que puede ver la compra

        }
    }
}

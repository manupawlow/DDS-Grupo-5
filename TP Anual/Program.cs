using System;
using TP_Anual.Egresos;
using TP_Anual.Administrador_Inicio_Sesion;
using Quartz;

namespace TP_Anual
{
    class Program
    {
        static void Main(string[] args)
        {
           
            DateTime fecha = DateTime.Today;
            DocumentoComercial doc = new DocumentoComercial(1, "ticket");
            MedioDePago medio = new MedioDePago("tarjeta", "debito");
            MenorValor criterioDeMenorValor = new MenorValor();
            Egreso egreso = new Egreso(fecha, doc, medio, 2, new BandejaDeMensajes("Grupo 5"));

            Proveedor proveedor1 = new Proveedor(20305006501, 10, "razon1");
            Proveedor proveedor2 = new Proveedor(20305006502, 11, "razon2");
            Proveedor proveedor3 = new Proveedor(20305006503, 12, "razon3");
            
            Item item1 = new Item(15000,"Galaxy s8");
            Item item2 = new Item(20000,"Galaxy s9");
            Item item3 = new Item(40000,"Galaxy s10");
            Item item4 = new Item(45000,"Galaxy s11");

            Presupuesto presupuesto1 = new Presupuesto(doc, proveedor1);
            Presupuesto presupuesto2 = new Presupuesto(doc, proveedor2);
           
            presupuesto1.agregar_item(item1);
            presupuesto1.agregar_item(item2);

            presupuesto2.agregar_item(item3);
            presupuesto2.agregar_item(item4);

            egreso.agregarPresupuesto(presupuesto1);
            egreso.agregarPresupuesto(presupuesto2);
            egreso.elegirCriterioDeSeleccion(criterioDeMenorValor);
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

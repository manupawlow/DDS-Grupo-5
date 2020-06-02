using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TP_ANUAL_DDS.Egresos;

namespace TP_ANUAL_DDS
{
    class Program
    {
        static void Main(string[] args)
        {
            //InterfazInicioDeSesion interfaz = new InterfazInicioDeSesion();
            MenorValor criterioDeMenorValor = new MenorValor();
            string usuarioActual;

            DateTime fecha = DateTime.Today;
            DocumentoComercial doc = new DocumentoComercial(1, "ticket");
            Proveedor proveedor1 = new Proveedor(20305006501, 10, "razon1");
            Proveedor proveedor2 = new Proveedor(20305006502, 11, "razon2");
            Proveedor proveedor3 = new Proveedor(20305006503, 12, "razon3");
            MedioDePago medio = new MedioDePago("tarjeta", "debito");

            Egreso egreso = new Egreso(fecha, doc, medio, 2, proveedor1, new BandejaDeMensajes("Grupo 5"));

            Item item1 = new Item("Galaxy s8");
            Item item2 = new Item("Galaxy s9");
            Item item3 = new Item("Galaxy s10");
            Item item4 = new Item("Galaxy s11");

            ItemDeProveedor itemp1 = new ItemDeProveedor(500, "Galaxy s8");
            ItemDeProveedor itemp1d = new ItemDeProveedor(499, "Galaxy s8");
            ItemDeProveedor itemp2 = new ItemDeProveedor(600, "Galaxy s9");
            ItemDeProveedor itemp3 = new ItemDeProveedor(700, "Galaxy s10");
            ItemDeProveedor itemp4 = new ItemDeProveedor(800, "Galaxy s11");

            egreso.agregarItem(item1);
            egreso.agregarItem(item2);
            egreso.agregarItem(item3);
            egreso.agregarItem(item4);

            proveedor1.agregarItem(itemp1d);
            proveedor1.agregarItem(itemp2);
            proveedor1.agregarItem(itemp3);
            proveedor1.agregarItem(itemp4);

            proveedor2.agregarItem(itemp1);
            proveedor2.agregarItem(itemp2);
            proveedor2.agregarItem(itemp3);
            proveedor2.agregarItem(itemp4);

            egreso.agregarProveedor(proveedor1);
            egreso.agregarProveedor(proveedor2);

            proveedor1.asignarEgreso(egreso);
            proveedor2.asignarEgreso(egreso);
            proveedor3.asignarEgreso(egreso);

            egreso.definirCriterioDeSeleccion(criterioDeMenorValor);

            /*List<Proveedor> list = egreso.proveedores.ToList();
            Console.WriteLine(list.Count);
            foreach (Proveedor value in list)
            {
                Console.WriteLine(value.presupuesto().valorTotal);
            }*/


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

            

            //Console.WriteLine(egreso.valorTotal);

            //BandejaDeMensajes.mostrarMensajes();
            
            //usuarioActual = interfaz.inicioDeSesion();
            //Console.WriteLine(usuarioActual);
            //con ese usuario, el validador se fija si es el usuario que puede ver la compra

        }
    }
}

using System;
using TP_ANUAL_DDS.Egresos;

namespace TP_ANUAL_DDS
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfazInicioDeSesion interfaz = new InterfazInicioDeSesion();

            DateTime fecha = DateTime.Today;
            DocumentoComercial doc = new DocumentoComercial(1, "ticket");
            Proveedor proveedor = new Proveedor(20305006505, 10, "Samsung");
            MedioDePago medio = new MedioDePago("tarjeta", "debito");

            Egreso egreso = new Egreso(fecha,doc,proveedor,medio);

            Item item1 = new Item(20000,"Galaxy s9");
            Item item2 = new Item(25000,"Galaxy s10");

            egreso.agregarItem(item1);
            egreso.agregarItem(item2);

            egreso.calcularValorTotal();

            Console.WriteLine(egreso.valorTotal);

            BandejaDeMensajes.agregarMensaje("hola");
            BandejaDeMensajes.mostrarMensajes();
            
            interfaz.inicioDeSesion();

        }
    }
}

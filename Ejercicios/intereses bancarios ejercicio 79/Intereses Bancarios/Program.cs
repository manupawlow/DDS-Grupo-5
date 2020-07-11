using System;

namespace Intereses_Bancarios
{
    class Program
    {
        static void Main(string[] args)
        {
            TarjetaDeCredito tarjeta = new TarjetaDeCredito();
            
            Intereses intereses = new Intereses();
            
            tarjeta.setIntereses(100);

            Console.WriteLine("los intereses de la tarjeta son: ");
            
            Console.WriteLine(tarjeta.getIntereses());
            
            Console.WriteLine("Los intereses con el aumento son: ");
            
            Console.WriteLine(tarjeta.accept(intereses));

            
            Cuenta cuenta = new Cuenta();
            
            cuenta.setMontoTotal(100);
            
            Console.WriteLine("El monto total de la cuenta es: ");
            
            Console.WriteLine(cuenta.getMontoTotal());
            
            Console.WriteLine("El monto con el descuento aplicado es: ");
            
            Console.WriteLine(cuenta.accept(intereses));

        }
    }
}

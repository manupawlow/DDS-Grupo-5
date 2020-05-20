using System;

namespace Organizaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Organizacion organizacion = new Organizacion();

            Console.WriteLine($"Tipo de Organizacion: {organizacion.TipoOrganizacion.Tipo}");
            Console.WriteLine($"Categoría de la Organización: {organizacion.TipoOrganizacion.Categoria}");
    
        }
    }
}

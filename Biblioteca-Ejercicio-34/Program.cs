using System;
using System.ComponentModel;
using System.Linq;
using Biblioteca_Ejercicio_34.Modelo;

namespace Biblioteca_Ejercicio_34
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BaseDeDatos())
            {
                Console.WriteLine("1.Retirar libro");
                Console.WriteLine("2.Devolver libro");
                Console.WriteLine("3.Calcular multa");
                
                while (true)
                {
                    var eleccion = Convert.ToInt32(Console.ReadLine());

                    switch (eleccion)
                    {
                        case 1:

                            var autor = new Autor();
                            autor.fecha_nacimiento = 1970;
                            autor.nombre = "Pedro";
                            context.autores.Add(autor);
                            context.SaveChanges();

                            var lector = new Lector();
                            lector.nombre = "Matias";
                            context.lectores.Add(lector);
                            context.SaveChanges();

                            var libro = new Libro();
                            libro.nombre = "Harry Potter";
                            libro.anio = 2008;
                            libro.categoria = "Magia";
                            libro.autor = autor;
                            context.libros.Add(libro);
                            context.SaveChanges();

                            lector = context.lectores.Single(l => l.id == 1);
                            if (lector.prestamos.Count() <= 3)
                            {
                                var prestamo = new Prestamo();
                                prestamo.lector = lector;
                                prestamo.libro = libro;
                                prestamo.fecha = 5;
                                context.prestamos.Add(prestamo);
                                context.SaveChanges();
                            }
                            else
                                Console.WriteLine("El lector ya tiene en su poder 3 libros");

                            

                            Console.WriteLine("Ingrese id libro a retirar");
                            eleccion = Convert.ToInt32(Console.ReadLine());
                            


                            break;
                        case 2:
                            Console.WriteLine("Ingrese nombre del libro");
                            break;

                        case 0:
                            break;
                    }

                    Console.WriteLine("1.Retirar libro");
                    Console.WriteLine("2.Devolver libro");
                    Console.WriteLine("3.Calcular multa");

                }
            }
        }

    }
}

using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Biblioteca_Ejercicio_34.Modelo;

namespace Biblioteca_Ejercicio_34
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BaseDeDatos())
            {

                // Agrego autor
                var autor = new Autor();
                autor.fecha_nacimiento = 1965;
                autor.nombre = "Rowling";
                if (!context.autores.Any(autor => autor.nombre == "Rowling"))
                    context.autores.Add(autor);
                context.autores.Add(autor);
                context.SaveChanges();

                // Agrego lector si no existe 
                var lector = new Lector();
                lector.nombre = "Matias";
                if (!context.lectores.Any(lector => lector.nombre == "Matias"))
                     context.lectores.Add(lector);
                context.SaveChanges();

                // Agrego libros si no existen
                var libro = new Libro();
                libro.nombre = "Harry Potter";
                libro.anio = 1997;
                libro.categoria = "Magia";
                libro.editorial = "Salamandra Bolsillo";
                libro.autor = autor;
                if(!context.libros.Any(libro => libro.nombre == "Harry Potter"))
                    context.libros.Add(libro);
                context.SaveChanges();

                libro = new Libro();
                libro.nombre = "Harry Potter 2";
                libro.anio = 1998;
                libro.categoria = "Magia";
                libro.editorial = "Salamandra Bolsillo";
                libro.autor = autor;
                if (!context.libros.Any(libro => libro.nombre == "Harry Potter 2"))
                    context.libros.Add(libro);
                context.SaveChanges();

                libro = new Libro();
                libro.nombre = "Harry Potter 3";
                libro.anio = 1999;
                libro.categoria = "Magia";
                libro.editorial = "Salamandra Bolsillo";
                libro.autor = autor;
                if (!context.libros.Any(libro => libro.nombre == "Harry Potter 3"))
                    context.libros.Add(libro);
                context.SaveChanges();

                libro = new Libro();
                libro.nombre = "Harry Potter 4";
                libro.anio = 2000;
                libro.categoria = "Magia";
                libro.editorial = "Salamandra Bolsillo";
                libro.autor = autor;
                if (!context.libros.Any(libro => libro.nombre == "Harry Potter 4"))
                    context.libros.Add(libro);
                context.SaveChanges();


                while (true)
                {
                    Console.WriteLine("Ingrese nombre de usuario:");
                    var usuario = Console.ReadLine();
                    int eleccion;

                    if(context.lectores.Any(lector => lector.nombre == usuario))
                    {
                        lector = context.lectores.Single(l => l.nombre == usuario);
                        Console.WriteLine("1.Retirar libro");
                        Console.WriteLine("2.Devolver libro");
                        Console.WriteLine("3.Calcular multa");

                        eleccion = Convert.ToInt32(Console.ReadLine());
                    }
                    else 
                    {
                        Console.WriteLine("El usuario ingresado no se encuentra en la base de datos");
                        eleccion = 0;
                    }

                    switch (eleccion)
                    {
                        case 1:

                            if (lector.dias_multado == 0 && lector.cant_libros < 3)
                            {
                                Console.WriteLine("Ingrese el nombre del libro a retirar");
                                var retirar = Console.ReadLine();

                                if (context.libros.Any(libros => libros.nombre == retirar))
                                {
                                    libro = context.libros.Single(libro => libro.nombre == retirar);
                                    if (libro.en_biblioteca)
                                    {
                                        var prestamo = new Prestamo();
                                        prestamo.lector = lector;
                                        prestamo.libro = libro;
                                        prestamo.fecha = 5;
                                        libro.prestar_libro(prestamo.fecha);
                                        lector.libro_prestado(prestamo);
                                        context.prestamos.Add(prestamo);
                                        context.SaveChanges();
                                        Console.WriteLine("Tiene 30 dias para devolver el libro!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("El libro solocitado no se encuentra en la biblioteca :(");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No tenemos ese libro :(");
                                }
                            }
                            else 
                            {
                                if (lector.dias_multado != 0)
                                    Console.WriteLine($"No puede retirar libros, esta multado por {lector.dias_multado} dias");
                                else
                                    Console.WriteLine("No puede retirar mas libros, la cantidad maxima es 3 libros por persona :(");
                            }

                            break;

                        case 2:
                            Console.WriteLine("Ingrese el nombre del libro a devolver");
                            var devolver = Console.ReadLine();
                            if (context.libros.Any(libros => libros.nombre == devolver))
                            {
                                var prest = context.prestamos.Single(prestamo => prestamo.libro.nombre == devolver);
                                lector.devolver_libro(prest, 50);
                                context.SaveChanges();
                                Console.WriteLine("Gracias, espero que haya disfrutado de la lectura!");
                            }
                            else
                                Console.WriteLine("Usted nunca retiro ese libro");
                            
                            break;

                        case 3:
                            Console.WriteLine($"Cantidad de dias multado:{lector.dias_multado}");

                            break;

                        case 0:
                            break;
                    }

                }
            }
        }

    }
}

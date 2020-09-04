using System;

using System.Collections.Generic;
using System.Linq;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DB())
            {
                //var cantPersonas = context.personas.ToArray();
                //Console.WriteLine(cantPersonas);
                /*
                var persona = new Persona();
                persona.dni = 11111;
                persona.nombre = "juan5";
                context.personas.Add(persona);
                

                var nuevoPost = new Perro();
                nuevoPost.nombre = "firulais 3";
                nuevoPost.duenio = persona;
                context.perros.Add(nuevoPost);
                
                persona.perros = (List<Perro>)new List<Perro> { nuevoPost };
                
                context.SaveChanges();


                var usuario = context.personas.Single(x => x.nombre == "juan5");


                var nuevoPost2 = new Perro();
                nuevoPost2.nombre = "firulais 9";
                nuevoPost2.duenio = usuario;
                context.perros.Add(nuevoPost2);
                context.SaveChanges(); 
                
                  var cantPersonas = context.personas.ToArray();
                  foreach(Persona p in cantPersonas)
                  {
                      Console.WriteLine(p.id + " - " + p.nombre);
                  }

                Console.WriteLine("--------------------\n");
                foreach(Perro p in usuario.perros)
                {
                    Console.WriteLine(p.nombre);
                }
            */

                /*var perro = new Perro();
                perro.nombre = "firulais a";
                perro.duenio = usuario;
                context.perros.Add(perro);

                var perro2 = new Perro();
                perro2.nombre = "firulais b";
                perro2.duenio = usuario;
                context.perros.Add(perro2);

                usuario.perros.Add(perro);
                usuario.perros.Add(perro2);
                
                context.SaveChanges();

                var perrosDeUsuario = context.perros.ToList().FindAll(a => a.id_duenio == usuario.id);
                */

                var juan = context.personas.Single(x => x.nombre == "juan5");
                
                foreach (Perro p in juan.perros)
                {
                    Console.WriteLine(p.nombre);
                }

            }

        }
    }
}

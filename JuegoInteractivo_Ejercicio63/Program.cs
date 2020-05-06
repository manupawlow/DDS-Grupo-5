using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Ejercicio63
{
    class MainClass
    {
        public static void Main()
        {


        }
    }

    class Personaje : ICloneable
    {
        public string nombre;
        public double altura;
        public int inteligencia;
        public int habilidades;
        public int peso;
        public Tipo tipo;

        public object Clone()
        {


            return this.Clone();
        }

    }

    class Heroe : Personaje
    {

    }

    class Villano : Personaje
    {

    }

    class Principe : Personaje
    {

    }

    class Monstruo : Personaje
    {

    }

    class Tipo
    {

    }

    class Malo : Tipo
    {

    }

    class Bueno : Tipo
    {

    }

    class Listo : Tipo
    {

    }

    class Bobo : Tipo
    {

    }

    class Sesion
    {
        public List<Personaje> personajes = new List<Personaje>();
        public List<Personaje> personajesClonados;

        public void crearPersonaje(Personaje personaje)
        {
            personajes.Add(personaje);
        }


        public List<Personaje> clonarPersonajes()
        {
            foreach (Personaje personaje in personajes)
            {
                Personaje personajeClonado = (Personaje)personaje.Clone();
                personajesClonados.Add(personajeClonado);
            }
            return personajesClonados;
        }

        public Personaje elegirPersonaje(Personaje personaje)
        {
            return personaje;
        }


    }

    class Sistema
    {

        public List<Sesion> sesiones = new List<Sesion>();

        public void crearSesion()
        {
            Sesion sesionNueva = new Sesion();
            Sesion sesionAnterior = new Sesion();

            if (sesiones != null)
            {
                sesionAnterior = sesiones.Last();
                sesionNueva.personajes = sesionAnterior.clonarPersonajes();
            }
            sesiones.Add(sesionNueva);

        }
    }

}
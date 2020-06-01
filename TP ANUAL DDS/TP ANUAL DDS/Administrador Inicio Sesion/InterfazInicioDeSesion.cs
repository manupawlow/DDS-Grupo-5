using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS
{
    class InterfazInicioDeSesion
    {

        CreadorUsuarios creador = new CreadorUsuarios();
        string usuarioActual;

        public string inicioDeSesion()
        {
            Console.WriteLine("1. Crear Usuario // 2. Ingresar");
            var eleccion = Console.ReadLine();
            while(eleccion == "1")
            {
                crearUsuario();
                Console.WriteLine("1. Crear Usuario // 2. Ingresar");
                eleccion = Console.ReadLine();
            }

            if (eleccion == "2")
            {
                ingresarCuenta();
                return usuarioActual;
            }

            return "Fin";
        }


        private void crearUsuario()
        {
            Usuario nuevo;

            string nombre;
            string contrasenia;
            string tipo;

            do
            {
                Console.WriteLine("Ingrese nombre de usuario: ");
                nombre = Console.ReadLine();

                Console.WriteLine("Ingrese contraseña: ");
                contrasenia = Console.ReadLine();

                if (creador.nombreDeUsuarioExistente(nombre))
                    Console.WriteLine("Nombre de usuario ya existe. Intente denuevo.\n");
                if (!Validador.validarContrasenia(contrasenia))
                    Console.WriteLine("Contraseña no valida. Intente denuevo");

            } while (creador.nombreDeUsuarioExistente(nombre) || !Validador.validarContrasenia(contrasenia));


            Console.WriteLine("Es administrador? Pulse la tecla 1 si lo es, caso contrario pulse cualquier otra tecla. ");
            tipo = Console.ReadLine();
            if (tipo == "1")
                nuevo = new Usuario(nombre, contrasenia, true);
            else
                nuevo = new Usuario(nombre, contrasenia, false);

            creador.archivarUsuario(nuevo);

            Console.WriteLine("Usuario creado con exito!");

        }

        private void ingresarCuenta()
        {
            string nombre;
            string contrasenia;

            do
            {
                Console.WriteLine("Ingrese nombre de usuario: ");
                nombre = Console.ReadLine();

                Console.WriteLine("Ingrese contraseña: ");
                contrasenia = Console.ReadLine();

                if (!creador.usuarioYContraseniaCorrecta(nombre, contrasenia))
                    Console.WriteLine("Invalido. Intentelo denuevo.");

            } while (!creador.usuarioYContraseniaCorrecta(nombre, contrasenia));

            Console.WriteLine("Bienvenido " + nombre + "!");

            usuarioActual = nombre;

        }

    }
}

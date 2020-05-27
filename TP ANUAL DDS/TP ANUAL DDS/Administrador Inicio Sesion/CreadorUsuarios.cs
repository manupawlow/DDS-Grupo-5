using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TP_ANUAL_DDS
{
    class CreadorUsuarios
    {

        public CreadorUsuarios() { }


        public bool nombreDeUsuarioExistente(string nombre)
        {
            using (StreamReader archivo = new StreamReader("Usuarios.txt"))
            {
                while (!archivo.EndOfStream)
                {
                    string line = (archivo.ReadLine()).Split('>')[0];
                    if (line == nombre)
                    {
                        archivo.Close();
                        return true;
                    } 
                }

                return false;
            }
        }

        public void archivarUsuario(Usuario usuario)
        {
            StreamWriter archivo = File.AppendText("Usuarios.txt");
            archivo.WriteLine(usuario.nombre + ">" + usuario.contrasenia + ">" + usuario.esAdministrador + "\n");
            archivo.Close();
        }

        public bool usuarioYContraseniaCorrecta(string nombre, string contrasenia)
        {
            StreamReader archivo;
            bool esCorrecta = false;

            archivo = File.OpenText("Usuarios.txt");
            var linea = archivo.ReadLine();

            while(linea != null && esCorrecta == false)
            {
                var usuario_contrasenia = linea.Split('>');
                if (usuario_contrasenia[0] == nombre && usuario_contrasenia[1] == contrasenia)
                    esCorrecta = true;
                else
                    linea = archivo.ReadLine();
            }

            archivo.Close();

            return esCorrecta;
        }



    }
}

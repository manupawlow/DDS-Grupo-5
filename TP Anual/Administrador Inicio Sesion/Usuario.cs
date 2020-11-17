using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Administrador_Inicio_Sesion
{
    public class Usuario
    {
        public int id;
        public string nombre;
        public string contrasenia;
        public bool esAdministrador;


        public Usuario(string name, string pasword, bool type)
        {
            nombre = name;
            contrasenia = pasword;
            esAdministrador = type;
        }

    }
}
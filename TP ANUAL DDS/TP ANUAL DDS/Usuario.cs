using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TP_ANUAL_DDS
{
    class Usuario
    {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCodigo
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string contrasenia { get; set; }

        public List<Tweet> twits;

        public Usuario(int _id, string _nombre, string _contrasenia)
        {
            id = _id;
            nombre = _nombre;
            contrasenia = _contrasenia;
            twits = new List<Tweet>();
        }

        public Usuario(int _id, string _nombre, string _contrasenia, List<Tweet> _twits)
        {
            id = _id;
            nombre = _nombre;
            contrasenia = _contrasenia;
            twits = _twits;
        }

    }
}

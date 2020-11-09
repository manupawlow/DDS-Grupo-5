using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PruebaCodigo;

namespace PruebaWeb.DAOs
{
    public class UsuarioDAO
    {
        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia()
        {

            if (instancia == null)
            {

                Tweet t1 = new Tweet("Soy un twit");
                Tweet t2 = new Tweet("Soy un twit2");
                Tweet t3 = new Tweet("Soy un twit3");

                List<Tweet> twits = new List<Tweet>();
                twits.Add(t1); twits.Add(t2); twits.Add(t3);

                instancia = new UsuarioDAO();
                instancia
                    .add(new Usuario(1, "pepe", "lola", twits))
                    .add(new Usuario(2, "pepe2", "lola", twits))
                    .add(new Usuario(3, "carlos", "lola"));

            }


            return instancia;

        }

        public UsuarioDAO add(Usuario user)
        {
            usuarios.Add(user);
            return this;

        }

        public Usuario getUsuarioById(int id)
        {
            return usuarios.Find(x => x.id == id);
        }
    }
}
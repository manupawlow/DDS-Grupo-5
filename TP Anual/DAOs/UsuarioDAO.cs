using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Administrador_Inicio_Sesion;

namespace TP_Anual.DAOs
{
    public class UsuarioDAO
    {
        public static UsuarioDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new UsuarioDAO();
                /*Tweet t1 = new Tweet("Soy un twit");
                Tweet t2 = new Tweet("Soy un twit2");
                Tweet t3 = new Tweet("Soy un twit3");

                List<Tweet> twits = new List<Tweet>();
                twits.Add(t1); twits.Add(t2); twits.Add(t3); 

                instancia
                    .add(new Usuario(1, "pepe", "lola", twits))
                    .add(new Usuario(2, "pepe2", "lola", twits))
                    .add(new Usuario(3, "carlos", "lola"));*/
            }
            return instancia;
        }

        #region FUNCIONES
        public UsuarioDAO Add(Usuario user)
        {
            using (var context = new BaseDeDatos())
            {
                context.usuarios.Add(user);
            }
            return this;
        }

        public Usuario getUsuarioById(int id)
        {
            using (var context = new BaseDeDatos())
            {
                return context.usuarios.Single(p => p.id == id);
            }
        }

        public Usuario getUsuarioByUserName(string username)
        {
            using (var context = new BaseDeDatos())
            {
                return context.usuarios.Single(p => p.nombre == username);
            }
        }


        #endregion

    }
}

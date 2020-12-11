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

            }
            return instancia;
        }

        #region FUNCIONES
        public UsuarioDAO Add(Usuario user)
        {
            using (var context = new MySql())
            {
                context.usuarios.Add(user);
                context.SaveChanges();

                //MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un usuario de id:{user.id}");
            }
            return this;
        }

        public Usuario getUsuarioById(int id)
        {
            using (var context = new MySql())
            {
                return context.usuarios.Single(p => p.id == id);
            }
        }

        public Usuario getUsuarioByUserName(string username)
        {
            using (var context = new MySql())
            {
                return context.usuarios.SingleOrDefault(p => p.nombre == username);
            }
        }


        #endregion
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.DAOs
{
    public class CriterioCategoriaDAO
    {
        public static CriterioCategoriaDAO instancia = null;
        //public List<Usuario> usuarios = new List<Usuario>();

        private CriterioCategoriaDAO() { }

        public static CriterioCategoriaDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new CriterioCategoriaDAO();
            }

            return instancia;
        }

        #region Funciones
        public Criterio getCriterioByDescripcion(string descripcion)
        {
            using (var context = new MySql())
            {
                return context.criterios.Single(e => e.descripcion == descripcion);
            }
        }

        public Categoria getCategoriaByDescripcion(string descripcion)
        {
            using (var context = new MySql())
            {
                return context.categorias.Single(e => e.descripcion == descripcion);
            }
        }

        public CriterioCategoriaDAO AddCriterio(Criterio e)
        {
            using (var context = new MySql())
            {
                context.criterios.Add(e);
                context.SaveChanges();
            }
            return this;
        }

        public CriterioCategoriaDAO AddCategoria(Categoria e)
        {
            using (var context = new MySql())
            {
                context.categorias.Add(e);
                context.SaveChanges();
            }
            return this;
        }

        public CriterioCategoriaDAO AddCriterioPorItem(CriterioPorItem e)
        {
            using (var context = new MySql())
            {
                context.criterios_por_item.Add(e);
                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un criterio_por_item de id:{e.id_crit_por_item}");
            }
            return this;
        }
        #endregion

    }
}

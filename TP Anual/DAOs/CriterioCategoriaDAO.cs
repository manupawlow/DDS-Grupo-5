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

                try
                {
                    return context.criterios.Single(e => e.descripcion == descripcion);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }

            }
        }

        public Categoria getCategoriaByDescripcion(string descripcion)
        {
            using (var context = new MySql())
            {
                try
                {
                    return context.categorias.Single(e => e.descripcion == descripcion);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        public List<Criterio> getAllCriterios()
        {
            using (var context = new MySql())
            {
                return context.criterios
                    .ToList<Criterio>();
            }
        }

        public List<Categoria> getAllCategorias()
        {
            using (var context = new MySql())
            {
                return context.categorias
                    .ToList<Categoria>();
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

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado una nueva categoria para items de id:{e.id_categoria}");
            }
            return this;
        }

        public CriterioCategoriaDAO AddCriterioPorItem(CriterioPorItem e)
        {
            using (var context = new MySql())
            {
                context.criterios_por_item.Add(e);
                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un nuevo criterio para items de id:{e.id_crit_por_item}");
            }
            return this;
        }
        #endregion

    }
}

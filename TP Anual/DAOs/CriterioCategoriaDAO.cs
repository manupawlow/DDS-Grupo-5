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
                    return context.criterios.First(e => e.descripcion.ToString() == descripcion);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }

            }
        }

        public Criterio getCriterioByID(int id_criterio)
        {
            using (var context = new MySql())
            {

                try
                {
                    return context.criterios.First(c => c.id_criterio == id_criterio);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }

            }
        }

        public Categoria getCategoriaByID(int id_categoria)
        {
            using (var context = new MySql())
            {

                try
                {
                    return context.categorias.First(c => c.id_categoria == id_categoria);
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
                    return context.categorias.Single(e => e.descripcion.ToString() == descripcion);
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

        public CriterioCategoriaDAO AddCriterioPorItem(Criterio e)
        {
            using (var context = new MySql())
            {
                context.criterios.Add(e);
                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un nuevo criterio: {e.descripcion}");
            }
            return this;
        }
        #endregion

    }
}

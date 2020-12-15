using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;
using TP_Anual.ProcesoDeVinculacion;

namespace TP_Anual.DAOs
{
    public class IngresoDAO
    {
        public static IngresoDAO instancia = null;
        
        private IngresoDAO() { }

        public static IngresoDAO getInstancia()
        {

            if (instancia == null)
            {
                instancia = new IngresoDAO();
            }

            return instancia;
        }


        #region Funciones
        public Ingreso getIngresoById(int id)
        {
            using (var context = new MySql())
            {
                try 
                { 
                    return context.ingresos.Single(e => e.id_ingreso == id);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        public List<Ingreso> getAllIngreso()
        {
            using (var context = new MySql())
            {
                return context.ingresos.ToList<Ingreso>();
            }
        }

        public IngresoDAO Add(Ingreso e)
        {
            using (var context = new MySql())
            {
                context.ingresos.Add(e);
                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un ingreso de id:{e.id_ingreso}");
            }
            return this;
        }

        public IngresoDAO asociarFechaPrimerEgreso()
        {
            using (var context = new MySql())
            {
                var ingresos = context.ingresos.ToList<Ingreso>();
                var egresos = context.egresos.ToList<Egreso>();

                new FechaPrimerEgreso().vincular(ingresos, egresos);
                
                context.SaveChanges();

            }
            return this;

        }

        public IngresoDAO asociarValorPrimerEgreso()
        {
            using (var context = new MySql())
            {
                var ingresos = context.ingresos.ToList<Ingreso>();
                var egresos = context.egresos.ToList<Egreso>();

                new ValorPrimerEgreso().vincular(ingresos, egresos);

                context.SaveChanges();
            }
            return this;

        }

        public IngresoDAO asociarValorPrimerIngreso()
        {
            using (var context = new MySql())
            {
                var ingresos = context.ingresos.ToList<Ingreso>();
                var egresos = context.egresos.ToList<Egreso>();

                new ValorPrimerIngreso().vincular(ingresos, egresos);

                context.SaveChanges();
            }
            return this;

        }


        #endregion


    }
}

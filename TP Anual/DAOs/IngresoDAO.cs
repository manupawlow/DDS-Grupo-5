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
                    return context.ingresos.Include("egresos").Single(e => e.id_ingreso == id);
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
                return context.ingresos.Include("egresos").ToList<Ingreso>();
            }
        }

        public Ingreso Add(Ingreso ingreso)
        {
            using (var context = new MySql())
            {
                context.ingresos.Add(ingreso);
                context.SaveChanges();

                MongoDB.getInstancia().agregarLogABitacora($"Se ha creado un ingreso de id:{ingreso.id_ingreso}");
            }
            return ingreso;
        }

        public bool asociarFechaPrimerEgreso(string[] e, string [] i)
        {
            using (var context = new MySql())
            {

                var egresos = new List<Egreso>();
                var ingresos = new List<Ingreso>();

                for(int j=0; j<e.Length; j++)
                {
                    egresos.Add(EgresoDAO.getInstancia().getEgresoById(Int32.Parse(e[j])));
                }

                for (int k = 0; k < i.Length; k++)
                {
                    ingresos.Add(IngresoDAO.getInstancia().getIngresoById(Int32.Parse(i[k])));
                }
                
                if (egresos.Count == 0 || ingresos.Count == 0)
                {
                    return false;
                }
                else
                {
                    new FechaPrimerEgreso().vincular(ingresos, egresos);
                    return true;
                }

            }

        }

        public bool asociarValorPrimerEgreso(string[] e, string[] i)
        {
            using (var context = new MySql())
            {

                var egresos = new List<Egreso>();
                var ingresos = new List<Ingreso>();

                for (int j = 0; j < e.Length; j++)
                {
                    egresos.Add(EgresoDAO.getInstancia().getEgresoById(Int32.Parse(e[j])));
                }

                for (int j = 0; j < i.Length; j++)
                {
                    ingresos.Add(IngresoDAO.getInstancia().getIngresoById(Int32.Parse(i[j])));
                }

                if (egresos.Count == 0 || ingresos.Count == 0)
                {
                    return false;
                }
                else
                {
                    new ValorPrimerEgreso().vincular(ingresos, egresos);
                    return true;
                }

            }

        }

        public bool asociarValorPrimerIngreso(string[] e, string[] i)
        {
            using (var context = new MySql())
            {

                var egresos = new List<Egreso>();
                var ingresos = new List<Ingreso>();

                for (int j = 0; j < e.Length; j++)
                {
                    egresos.Add(EgresoDAO.getInstancia().getEgresoById(Int32.Parse(e[j])));
                }

                for (int j = 0; j < i.Length; j++)
                {
                    ingresos.Add(IngresoDAO.getInstancia().getIngresoById(Int32.Parse(i[j])));
                }

                if (egresos.Count == 0 || ingresos.Count == 0)
                {
                    return false;
                }
                else
                {
                    new ValorPrimerIngreso().vincular(ingresos, egresos);
                    return true;
                }

            }
        }

        public IngresoDAO agregarEgreso(Ingreso ingreso, Egreso egreso)
        {
            using (var context = new MySql())
            {
                ingreso.egresos.Add(egreso);
                context.SaveChanges();
            }

            return this;
        }


        #endregion


    }
}

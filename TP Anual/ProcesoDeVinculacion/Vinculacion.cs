using System;
using System.Collections.Generic;
using System.Linq;
using TP_Anual.Egresos;
using TP_Anual.DAOs;

namespace TP_Anual.ProcesoDeVinculacion
{

	public abstract class Vinculacion
	{
		public List<Condicion> condiciones = new List<Condicion>();

		public abstract void vincular(List<Ingreso> ingresos, List<Egreso> egresos);

		public void asociar(Ingreso ingreso, Egreso egreso)
		{

            using (var context = new MySql())
            {
                //var a = EgresoDAO.getInstancia().pepe(egreso);
                //var b = IngresoDAO.getInstancia().agregarEgreso(ingreso, egreso);
                ingreso.egresos.Add(egreso);
                egreso.ingreso = ingreso;
                egreso.descripcion = "daleee";

                context.SaveChanges();
            }
        }

		public Boolean cumplirCondiciones(Ingreso ingreso, Egreso egreso)
		{
			return condiciones.All(x => x.cumpleCondicion(ingreso, egreso));
		}

	}
}
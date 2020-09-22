using System;
using System.Collections.Generic;
using System.Linq;
using TP_Anual.Egresos;

namespace TP_Anual.ProcesoDeVinculacion
{

	public class Vinculacion
	{
		public List<Condicion> condiciones = new List<Condicion>();

		public virtual void vincular(List<Ingreso> ingresos, List<Egreso> egresos)
		{

		}

		public void asociar(Ingreso ingreso, Egreso egreso)
		{
			ingreso.egresos.Add(egreso);
			egreso.ingreso = ingreso;
		}

		public Boolean cumplirCondiciones(Ingreso ingreso, Egreso egreso)
		{
			return condiciones.All(x => x.cumpleCondicion(ingreso, egreso));
		}

	}
}
using System;
using System.Collections.Generic;
using TP_Anual.Egresos;
using System.Linq;


namespace TP_Anual.ProcesoDeVinculacion
{
	public class FechaPrimerEgreso : Vinculacion
	{
		public override void vincular(List<Ingreso> ingresos, List<Egreso> egresos)
		{

			int i = 0;
			IEnumerable<Ingreso> ingresosOrdenados = ingresos.OrderBy(x => x.fecha);
			IEnumerable<Egreso> egresosOrdenados = egresos.OrderBy(x => x.fecha);
			List<Egreso> egresosFinal = egresosOrdenados.ToList();
			List<Ingreso> ingresosFinal = ingresosOrdenados.ToList();

			foreach (Ingreso ingreso in ingresosFinal)
			{
				while (i < egresosFinal.Count() && ingreso.total >= ingreso.egresos.Sum(x => x.valorTotal) + egresosFinal[i].valorTotal)
				{
					if (this.cumplirCondiciones(ingreso, egresosFinal[i]))
					{
						asociar(ingreso, egresosFinal[i]);
						MongoDB.getInstancia().agregarLogABitacora($"Se ha asociado el ingreso de id:{ingreso.id_ingreso} al egreso de id:{egresosFinal[i].id_egreso}");
						i++;
					}
				}

			}
		}
	}
}
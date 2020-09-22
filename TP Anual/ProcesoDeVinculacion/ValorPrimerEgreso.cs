using System;
using System.Collections.Generic;
using System.Linq;
using TP_Anual.Egresos;

namespace TP_Anual.ProcesoDeVinculacion
{

	public class ValorPrimerEgreso : Vinculacion
	{
		public override void vincular(List<Ingreso> ingresos, List<Egreso> egresos)
		{
			int i = 0;
			IEnumerable<Ingreso> ingresosOrdenados = ingresos.OrderBy(x => x.total);
			IEnumerable<Egreso> egresosOrdenados = egresos.OrderBy(x => x.valorTotal);
			List<Egreso> egresosFinal = egresosOrdenados.ToList();
			List<Ingreso> ingresosFinal = ingresosOrdenados.ToList();

			int k = 0;
			int m = 0;



			foreach (Ingreso ingreso in ingresosFinal)
			{
				while (i < egresos.Count() && ingreso.total >= ingreso.egresos.Sum(x => x.valorTotal) + egresosFinal[i].valorTotal)
				{
					if (this.cumplirCondiciones(ingreso, egresosFinal[i]))
					{
						asociar(ingreso, egresosFinal[i]);

						
					}
					i++;
				}

			}

			Console.WriteLine("Ingresos ordenados");
			while (k < ingresos.Count)
			{
				Console.WriteLine(ingresosFinal[k].descripcion);
				k++;
			}
			Console.WriteLine("Egresos ordenados");
			while (m < egresos.Count)
			{
				Console.WriteLine(egresosFinal[m].descripcion);
				m++;
			}

			for (int j = 0; j < ingresosFinal.Count(); j++)
			{
				Console.Out.WriteLine("El ingreso:\n");
				Console.Out.WriteLine(ingresosFinal[j].descripcion);
				Console.Out.WriteLine("Posee los siguientes egresos:\n");
				for (int l = 0; l < ingresosFinal[j].egresos.Count; l++)
				{
					Console.Out.WriteLine(ingresosFinal[j].egresos[l].descripcion);

				}


			}
		}

	}
}

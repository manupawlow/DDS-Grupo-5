using System;
using System.Collections.Generic;
using System.Linq;
using TP_Anual.Egresos;

namespace TP_Anual.ProcesoDeVinculacion
{
	public class ValorPrimerIngreso : Vinculacion
	{
		public override void vincular(List<Ingreso> ingresos, List<Egreso> egresos)
		{
			int i = 0;
			int ingresosMaximosDeUnEgreso = 0;
			IEnumerable<Ingreso> ingresosOrdenados = ingresos.OrderBy(x => x.total);
			IEnumerable<Egreso> egresosOrdenados = egresos.OrderBy(x => x.valorTotal);
			List<Egreso> egresosFinal = egresosOrdenados.ToList();
			List<Ingreso> ingresosFinal = ingresosOrdenados.ToList();

			foreach (Egreso egreso in egresosFinal)
			{
				ingresosMaximosDeUnEgreso = 0;
				i = 0;
				while (i < ingresos.Count() && ingresosMaximosDeUnEgreso < 1)
				{
					if (this.cumplirCondiciones(ingresosFinal[i], egreso))
					{
						if (ingresosFinal[i].total >= ingresosFinal[i].egresos.Sum(x => x.valorTotal) + egreso.valorTotal)
						{
							asociar(ingresosFinal[i], egreso);
							ingresosMaximosDeUnEgreso++;

						}
					}
					i++;
				}

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

using System;
using System.Collections.Generic;
using System.Linq;
using TP_Anual.Egresos;

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
				var egreso_ = context.egresos.Single(e => e.id_egreso == egreso.id_egreso);
                var ingreso_ = context.ingresos.Single(i => i.id_ingreso == ingreso.id_ingreso);

				egreso_.ingreso = ingreso_;

                context.SaveChanges();
            }
        }

		public Boolean cumplirCondiciones(Ingreso ingreso, Egreso egreso)
		{
			return condiciones.All(x => x.cumpleCondicion(ingreso, egreso));
		}

	}
}
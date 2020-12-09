using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Administrador_Inicio_Sesion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
	[Table("proyecto_financiamiento")]
	public class ProyectoDeFinanciamiento
	{
		[Key]
		[Column("id_proyecto")]
		public int id { get; set; }

		[Column("presupuestos_exigibles")]
		public int cantPresupuestosExigibles { get; set; }

		[Column("monto_total")]
		public int montoTotal { get; set; }

		[Column("id_director")]
		public int id_director { get; set; }
		public Usuario director { get; set; }

		public List<Ingreso> ingresos = new List<Ingreso>();

		public ProyectoDeFinanciamiento()
        {
			ingresos = new List<Ingreso>();
		}

		public ProyectoDeFinanciamiento(int CantPresupuestosExigibles, int MontoTotal, Usuario Director)
		{
			cantPresupuestosExigibles = CantPresupuestosExigibles;
			montoTotal = MontoTotal;
			director = Director;
			ingresos = new List<Ingreso>();

		}

		public void agregarIngreso(Ingreso ingreso)
		{
			ingresos.Add(ingreso);
			GeneradorDeLogs.agregarLogABitacora($"Se ha agregado un nuevo ingreso de id: {ingreso.id_ingreso} al proyecto de id:{id} ");
		}

		public void cerrarProyecto()
		{
			GeneradorDeLogs.agregarLogABitacora($"El proyecto de id:{id} se ha dado de baja " );
		}

		public void evaluar(bool resultado)
		{
			if (resultado)
				GeneradorDeLogs.agregarLogABitacora("Se ha dado de alta el proyecto");
			else
				GeneradorDeLogs.agregarLogABitacora("Se ha rechazado el proyecto");

		}


	}
}

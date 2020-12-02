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
		public int id;

		public int cantPresupuestosExigibles;

		public int montoTotal;

		public Usuario director;

		public List<Ingreso> ingresos = new List<Ingreso>();

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
			GeneradorDeLogs.agregarLogABitacora("Se ha agregado un nuevo ingreso al proyecto");
		}

		public void cerrarProyecto()
		{
			GeneradorDeLogs.agregarLogABitacora("El proyecto se ha dado de baja");
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

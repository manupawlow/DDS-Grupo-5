using System;
using System.Collections.Generic;
using TP_Anual.Egresos;
using TP_Anual.ProcesoDeVinculacion;


namespace TP_Anual
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var contex = new MySql())
            {

                Egreso egreso = new Egreso();
                egreso.cantPresupuestos = 2;
                egreso.descripcion = "Alimentos";

                contex.egresos.Add(egreso);
                contex.SaveChanges();

                Egreso egreso2 = new Egreso();
                egreso2.cantPresupuestos = 2;
                egreso2.descripcion = "Celulares";

                contex.egresos.Add(egreso2);
                contex.SaveChanges();

                Ingreso ingreso = new Ingreso();
                ingreso.total = 15000;
                ingreso.descripcion = "Donacion";

                contex.ingresos.Add(ingreso);
                contex.SaveChanges();

            }


        }

    }

}

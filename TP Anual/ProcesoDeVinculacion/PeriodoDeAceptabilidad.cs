using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.ProcesoDeVinculacion
{
    public class PeriodoDeAceptabilidad : Condicion
    {
        public override Boolean cumpleCondicion(Ingreso ingreso, Egreso egreso)
        {
            long fechaDeIngreso =
               ingreso.fecha.Year * 10000000000 +
               ingreso.fecha.Month * 100000000 +
               ingreso.fecha.Day * 1000000 +
               ingreso.fecha.Hour * 10000 +
               ingreso.fecha.Minute * 100 +
               ingreso.fecha.Second;
            long fechaDeEgreso =
                egreso.fecha.Year * 10000000000 +
                egreso.fecha.Month * 100000000 +
                egreso.fecha.Day * 1000000 +
                egreso.fecha.Hour * 10000 +
                egreso.fecha.Minute * 100 +
                egreso.fecha.Second;
            return Math.Abs(fechaDeEgreso - fechaDeIngreso) < 5000000;

        }

    }
}

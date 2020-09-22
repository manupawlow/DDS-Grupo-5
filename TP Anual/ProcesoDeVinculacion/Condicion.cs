using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.ProcesoDeVinculacion
{
    public abstract class Condicion
    {
        public abstract Boolean cumpleCondicion(Ingreso ingreso, Egreso egreso);
    }
}

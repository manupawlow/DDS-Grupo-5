using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public abstract class ICriterioDeSeleccion
    {
        public abstract Presupuesto Criterio(List<Presupuesto> presupuestos);
        
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public interface ICriterioDeSeleccion
    {
        abstract Presupuesto Criterio(List<Presupuesto> prov);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    class MenorValor : ICriterioDeSeleccion
    {
        public Proveedor Criterio(List<Proveedor> provs)
        {
            Proveedor menorValor = provs[0];
            for(int i = 1; i < provs.Count(); i++)
            {
                if (menorValor.presupuesto().valorTotal > provs[i].presupuesto().valorTotal)
                    menorValor = provs[i];
            }
            return menorValor;
        }
    }
}

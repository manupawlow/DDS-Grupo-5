using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_Anual.Egresos
{
    class MenorValor : ICriterioDeSeleccion
    {
        
        public Proveedor Criterio(List<Proveedor> provs)
        {
            
            Proveedor menorValor = provs[0];
            for (int i = 1; i < provs.Count(); i++)
            {
                if (menorValor.Presupuesto().valorTotal > provs[i].Presupuesto().valorTotal)
                    menorValor = provs[i];
            }
            return menorValor;
            
        }
        
    }

}

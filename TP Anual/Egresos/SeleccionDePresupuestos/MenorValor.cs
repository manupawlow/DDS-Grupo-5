﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_Anual.Egresos
{
    class MenorValor : ICriterioDeSeleccion
    {
        
        public override Presupuesto Criterio(List<Presupuesto> Presupuestos)
        {
            
            Presupuesto menorValor = Presupuestos[0];

            for (int i = 1; i < Presupuestos.Count(); i++)
            {
                if (Presupuestos[i].valor_total < menorValor.valor_total )
                    menorValor = Presupuestos[i];
            }
            return menorValor;
            
        }
        
    }

}

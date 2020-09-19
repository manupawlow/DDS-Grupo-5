using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Organizaciones
{
    class Pequenia : Empresa
    {
        public Pequenia()
        {
            categoria = "Pequeña";

            tipo = "Empresa";

            topeVentasPorActividad = new Dictionary<string, float>()
            {
                {"Construcción", 90310000},
                {"Servicios", 50950000},
                {"Comercio", 178860000},
                {"Industria y Minería", 190410000},
                {"Agropecuario", 48480000}
            };

            base.topePersonalPorActividad = new Dictionary<string, int>()
            {
                {"Construcción", 45},
                {"Servicios", 30},
                {"Comercio", 35},
                {"Industria y Minería", 60},
                {"Agropecuario", 10}
            };
        }

        
    }
}

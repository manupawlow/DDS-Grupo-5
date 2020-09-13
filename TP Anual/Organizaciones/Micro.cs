using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Organizaciones
{
    class Micro : Empresa
    { 
        public Micro()
        {
            categoria = "Micro";

            topeVentasPorActividad = new Dictionary<string, float>()
            {
                {"Construcción", 15230000},
                {"Servicios", 8500000},
                {"Comercio", 29740000},
                {"Industria y Minería", 26540000},
                {"Agropecuario", 12890000}
            };

            base.topePersonalPorActividad = new Dictionary<string, int>()
            {
                {"Construcción", 12},
                {"Servicios", 7},
                {"Comercio", 7},
                {"Industria y Minería", 15},
                {"Agropecuario", 5}
            };
        }

    }
}

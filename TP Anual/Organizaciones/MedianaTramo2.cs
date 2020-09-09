using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Organizaciones
{
    class MedianaTramo2 : Empresa
    {
        public MedianaTramo2()
        {
            categoria = "Mediana - Tramo 2";

            topeVentasPorActividad = new Dictionary<string, float>()
            {
                {"Construcción", 755740000},
                {"Servicios", 607210000},
                {"Comercio", 2146810000},
                {"Industria y Minería", 1739590000},
                {"Agropecuario", 547890000}
            };

            base.topePersonalPorActividad = new Dictionary<string, int>()
            {
                {"Construcción", 590},
                {"Servicios", 535},
                {"Comercio", 345},
                {"Industria y Minería", 655},
                {"Agropecuario", 215}
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Organizaciones
{
    class MedianaTramo1 : Empresa
    {
        private readonly string categoria = "Mediana - Tramo 1";
        
        public MedianaTramo1()
        {
            topeVentasPorActividad = new Dictionary<string, float>()
            {
                {"Construcción", 503880000},
                {"Servicios", 425170000},
                {"Comercio", 1502750000},
                {"Industria y Minería", 1190330000},
                {"Agropecuario", 345430000}
            };

            base.topePersonalPorActividad = new Dictionary<string, int>()
            {
                {"Construcción", 200},
                {"Servicios", 165},
                {"Comercio", 125},
                {"Industria y Minería", 235},
                {"Agropecuario", 50}
            };
        }

        public override string Categoria { get => categoria; }
    }
}

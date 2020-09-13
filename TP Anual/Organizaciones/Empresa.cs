using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Organizaciones
{
    public abstract class Empresa : TipoOrganizacion
    {
        public string categoria;
        public Dictionary<string, float> topeVentasPorActividad;
        public Dictionary<string, int> topePersonalPorActividad;
       
        public float TopeVentasPorActividad(string actividad)
        {
            return topeVentasPorActividad[actividad];
        }
        public int TopePersonalPorActividad(string actividad)
        {
            return topePersonalPorActividad[actividad];
        }

    }
}

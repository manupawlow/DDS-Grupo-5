using System;
using System.Collections.Generic;
using System.Text;

namespace Organizaciones
{
    public abstract class Empresa : TipoOrganizacion
    {
        private readonly string tipo = "Empresa";
        protected Dictionary<string, float> topeVentasPorActividad;
        protected Dictionary<string, int> topePersonalPorActividad;
        

        public override string Tipo { get => tipo; }
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

using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    class Proveedor
    {
        private long cuit;
        private int direccionPostal;
        private string razonSocial;
        
        public Proveedor(long Cuit, int DireccionPostal, string RazonSocial)
        {
            cuit = Cuit;
            direccionPostal = DireccionPostal;
            razonSocial = RazonSocial;
        }

    }
}

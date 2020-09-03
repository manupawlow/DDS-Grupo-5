using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace TP_Anual.Egresos
{
    public class Proveedor
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

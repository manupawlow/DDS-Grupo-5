using System;
using System.Collections.Generic;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    public class MedioDePago
    {
        private string nombre { get; }
        private string tipoDePago { get; }

        public MedioDePago (string Nombre, string TipoDePago) 
        {
            nombre = Nombre;
            tipoDePago = TipoDePago;
        }
    }
}

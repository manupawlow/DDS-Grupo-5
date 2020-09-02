using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public interface ICriterioDeSeleccion
    {
        abstract Proveedor Criterio(List<Proveedor> prov);
    }
    /*public abstract class CriterioDeSeleccion
    {
        public abstract Proveedor Criterio(List<Proveedor> prov);
    }*/
}

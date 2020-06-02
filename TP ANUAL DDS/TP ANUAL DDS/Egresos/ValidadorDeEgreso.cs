using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    static class ValidadorDeEgreso
    {
        static public bool egresoValido(Egreso egreso) 
        {
            if (cantidadCorrecta(egreso))
                egreso.bandejaDeMensajes.agregarMensaje("Se encuentra cargada la cantidad indicada de presupuestos");
            else
                egreso.bandejaDeMensajes.agregarMensaje("No se encuentra cargada la cantidad indicada de presupuestos");
            if (presupuestoElegido(egreso))
                egreso.bandejaDeMensajes.agregarMensaje("La compra se realizo en base a algun presupuesto de la lista de los proveedores");
            else
                egreso.bandejaDeMensajes.agregarMensaje("La compra no se realizo en base a algun presupuesto de la lista de los proveedores");
            if (criterioDeSeleccion(egreso))
                egreso.bandejaDeMensajes.agregarMensaje("La eleccion del presupuesto coincide con el criterio de seleccion");
            else
                egreso.bandejaDeMensajes.agregarMensaje("La eleccion del presupuesto no coincide con el criterio de seleccion");

            return cantidadCorrecta(egreso) && presupuestoElegido(egreso) && criterioDeSeleccion(egreso);
        }

        static private bool cantidadCorrecta (Egreso egreso)
        {
            if (egreso.cantPresupuestos == 0)
                return false;
            else
                return egreso.cantPresupuestos == egreso.proveedores.Count();
        }
        static private bool presupuestoElegido(Egreso egreso)
        {            
            return egreso.proveedores.Any(Proveedor => Proveedor.presupuesto() == egreso.proveedorElegido.presupuesto());
        }
        static private bool criterioDeSeleccion(Egreso egreso)
        {
            return egreso.Criterio(egreso.proveedores) == egreso.proveedorElegido;
        }
    }
}

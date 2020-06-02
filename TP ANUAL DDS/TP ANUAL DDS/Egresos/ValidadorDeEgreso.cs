using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TP_ANUAL_DDS.Egresos
{
    class ValidadorDeEgreso
    {
        public bool egresoValido(Egreso egreso) 
        {
            if (cantidadCorrecta(egreso))
                BandejaDeMensajes.agregarMensaje("Se encuentra cargada la cantidad indicada de presupuestos");
            else
                BandejaDeMensajes.agregarMensaje("No se encuentra cargada la cantidad indicada de presupuestos");
            if (presupuestoElegido(egreso))
                BandejaDeMensajes.agregarMensaje("La compra se realizo en base a algun presupuesto de la lista de los proveedores");
            else
                BandejaDeMensajes.agregarMensaje("La compra no se realizo en base a algun presupuesto de la lista de los proveedores");
            if (criterioDeSeleccion(egreso))
                BandejaDeMensajes.agregarMensaje("La eleccion del presupuesto coincide con el criterio de seleccion");
            else
                BandejaDeMensajes.agregarMensaje("La eleccion del presupuesto no coincide con el criterio de seleccion");

            return cantidadCorrecta(egreso) && presupuestoElegido(egreso) && criterioDeSeleccion(egreso);
        }

        private bool cantidadCorrecta (Egreso egreso)
        {
            if (egreso.cantPresupuestos == 0)
                return false;
            else
                return egreso.cantPresupuestos == egreso.proveedores.Count();
        }
        private bool presupuestoElegido(Egreso egreso)
        {            
            return egreso.proveedores.Any(Proveedor => Proveedor.presupuesto() == egreso.proveedorElegido.presupuesto());
        }
        private bool criterioDeSeleccion(Egreso egreso)
        {
            return egreso.Criterio(egreso.proveedores) == egreso.proveedorElegido;
        }
    }
}

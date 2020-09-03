using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace TP_Anual.Egresos
{
    static class ValidadorDeEgreso
    {
        static public bool egresoValido(Egreso egreso)
        {
           

            if (egreso.cantPresupuestos == 0)
            {
                egreso.bandejaDeMensajes.agregarMensaje("La compra no requiere presupuestos!");
                return true;
            }
            else 
            {
                if (cantidadCorrecta(egreso))
                    egreso.bandejaDeMensajes.agregarMensaje("Se encuentra cargada la cantidad indicada de presupuestos");
                else
                    egreso.bandejaDeMensajes.agregarMensaje("No se encuentra cargada la cantidad indicada de presupuestos");

                if (presupuestoCoincidente(egreso))
                    egreso.bandejaDeMensajes.agregarMensaje("La compra se realizo en base a la lista de presupuestos");
                else
                    egreso.bandejaDeMensajes.agregarMensaje("La compra no se realizo en base a lista de presupuestos");

                if (criterioDeSeleccion(egreso))
                    egreso.bandejaDeMensajes.agregarMensaje("La eleccion del presupuesto coincide con el criterio de seleccion");
                else
                    egreso.bandejaDeMensajes.agregarMensaje("La eleccion del presupuesto no coincide con el criterio de seleccion");
            }
            

            return cantidadCorrecta(egreso) && presupuestoCoincidente(egreso) && criterioDeSeleccion(egreso);
        }

        static private bool cantidadCorrecta(Egreso egreso)
        {
                return egreso.cantPresupuestos == egreso.presupuestos.Count();
        }
        static private bool presupuestoCoincidente(Egreso egreso)
        { 
            Presupuesto presupuesto_elegido = egreso.presupuestoElegido;
            return egreso.presupuestos.Any(Presupuesto => presupuesto_elegido == Presupuesto);
        }
        static private bool criterioDeSeleccion(Egreso egreso)
        {
            return egreso.criterioDeSeleccion.Criterio(egreso.presupuestos) == egreso.presupuestoElegido;
        }
    }
}

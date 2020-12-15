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
            
            egreso.bandejaDeMensajes.agregarMensaje("-----------------Comienzo validacion:");

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
                {
                    if (egreso.presupuestoElegido == null)
                        egreso.bandejaDeMensajes.agregarMensaje("No se selecciono un presupuesto para comprobar si se encuentra entre los presupuestos asignados");
                    else
                        egreso.bandejaDeMensajes.agregarMensaje("La compra no se realizo en base a lista de presupuestos");
                }
                    

                if (criterioDeSeleccion(egreso))
                    egreso.bandejaDeMensajes.agregarMensaje("La eleccion del presupuesto coincide con el criterio de seleccion");  
                else 
                {
                    if (egreso.presupuestos.Count() == 0)
                        egreso.bandejaDeMensajes.agregarMensaje("El egreso no tiene presupuestos asignados para analizar el criterio de seleccion");
                    else
                    {
                        if(egreso.presupuestoElegido == null)
                            egreso.bandejaDeMensajes.agregarMensaje("No se selecciono un presupuesto para analizar el criterio");
                        else
                            egreso.bandejaDeMensajes.agregarMensaje("La eleccion del presupuesto no coincide con el criterio de seleccion");
                    }
                        
                }
                    

                if (egreso.proyecto != null) 
                {
                    if (cumpleCantidadDePresupuestosExigibles(egreso))
                        egreso.bandejaDeMensajes.agregarMensaje("El egreso cumple con los presupuestos del proyecto financiamiento");
                    else
                        egreso.bandejaDeMensajes.agregarMensaje("El egreso no posee la cantidad de presupuestos exigibles del proyecto financiamiento");
                }
                else
                {
                    egreso.bandejaDeMensajes.agregarMensaje("El egreso no tiene un proyecto de financiamiento");
                }
                
                

            }


            return cantidadCorrecta(egreso) &&
                   presupuestoCoincidente(egreso) &&
                   criterioDeSeleccion(egreso) &&
                   cumpleCantidadDePresupuestosExigibles(egreso);
        }

        static private bool cantidadCorrecta(Egreso egreso)
        {
            return egreso.cantPresupuestos == egreso.presupuestos.Count();
        }
        static private bool presupuestoCoincidente(Egreso egreso)
        {
            Presupuesto presupuesto_elegido = egreso.presupuestoElegido;
            return egreso.presupuestos.Any(Presupuesto => presupuesto_elegido.id_presupuesto == Presupuesto.id_presupuesto);
            
        }
        static private bool criterioDeSeleccion(Egreso egreso)
        {
            if(egreso.presupuestos.Count == 0)
            {
                return false;
            }else
            {
                return egreso.criterioDeSeleccion.Criterio(egreso.presupuestos) == egreso.presupuestoElegido;
            }
            
        }

        static private bool cumpleCantidadDePresupuestosExigibles(Egreso egreso)
        {
            if (egreso.proyecto != null)
                return egreso.proyecto.cantPresupuestosExigibles <= egreso.presupuestos.Count;
            else
                return false;
        }

    }
}

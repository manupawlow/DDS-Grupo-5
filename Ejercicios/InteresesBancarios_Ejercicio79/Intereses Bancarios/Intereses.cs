using System;
using System.Collections.Generic;
using System.Text;

namespace Intereses_Bancarios
{
    class Intereses : Visitor
    {

        public double visit(TarjetaDeCredito tarjeta)
        {

            double porcentajeDeInteres = 0.05;

            double interesActualizado = tarjeta.getIntereses() + tarjeta.getIntereses() * porcentajeDeInteres;

            tarjeta.setIntereses(interesActualizado);

            return interesActualizado;

            

        }

        public double visit(Cuenta cuenta)
        {

            double porcentajeDeDescuento = 0.01;

            double montoActualizado = cuenta.getMontoTotal() - cuenta.getMontoTotal() * porcentajeDeDescuento;

            cuenta.setMontoTotal(montoActualizado);

            return montoActualizado;

        }

    }
}

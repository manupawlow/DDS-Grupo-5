using System;
using System.Collections.Generic;
using System.Text;

namespace Intereses_Bancarios
{
    class Cuenta : Visitable
    {

        public double montoTotal;

        public double accept(Visitor visitor)
        {
            return visitor.visit(this);
        }

        public void setMontoTotal(double nuevoMonto)
        {

            this.montoTotal = nuevoMonto;

        }

        public double getMontoTotal()
        {
            return this.montoTotal;
        }

    }
}

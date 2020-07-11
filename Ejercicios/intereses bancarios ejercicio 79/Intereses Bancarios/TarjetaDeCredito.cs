using System;
using System.Collections.Generic;
using System.Text;

namespace Intereses_Bancarios
{
    class TarjetaDeCredito : Visitable
    {

        public double intereses;

        public double accept(Visitor visitor)
        {
            return visitor.visit(this);
        }

        public void setIntereses(double nuevoInteres)
        {

            this.intereses = nuevoInteres;

        }

        public double getIntereses()
        {
            return this.intereses;
        }
    }
}

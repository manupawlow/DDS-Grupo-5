using System;
using System.Collections.Generic;
using System.Text;

namespace Intereses_Bancarios
{
    interface Visitor
    {
        public double visit(TarjetaDeCredito tarjetaDeCredito);

        double visit(Cuenta cuenta);

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Organizaciones
{
    public abstract class TipoOrganizacion
    {
        public abstract string Tipo { get; }
        public abstract string Categoria { get; }
    }
}

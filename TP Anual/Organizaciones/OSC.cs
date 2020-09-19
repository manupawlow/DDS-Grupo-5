using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    class OSC : TipoOrganizacion
    {
        public OSC() 
        {
            tipo = "OSC";

            categoria = "No tiene";
        }

    }
}

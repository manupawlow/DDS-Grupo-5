using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    //[Table("OSC")]
    class OSC : TipoOrganizacion
    {
      /*  [Key]
        [Column("id_osc")]
        public int id_osc { get; set; }
        */

        public OSC() 
        {
            tipo = "OSC";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    [Table("tipo_organizacion")]
    public abstract class TipoOrganizacion
    {
        [Key]
        [Column("id_tipo")]
        public int id_tipo { get; set; }

        [Column("tipo")]
        public string tipo { get; set; }

        [Column("categoria")]
        public string categoria { get; set; }

        public string discriminador { get; set; }

    }
}

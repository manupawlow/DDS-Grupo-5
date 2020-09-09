using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    [Table("tipo_organizacion")]
    public class TipoOrganizacion
    {
        [Key]
        [Column("id_tipo")]
        public int id_tipo { get; set; }

        [Column("tipo")]
        public string tipo { get; set; }

    }
}

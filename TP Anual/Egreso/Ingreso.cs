using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("ingreso")]
    class Ingreso
    {
        [Key]
        [Column("id_ingreso")]
        public int id_ingreso { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("total")]
        public int total { get; set; }

        [Column("id_egreso")]
        public int id_egreso { get; set; }
    }
}

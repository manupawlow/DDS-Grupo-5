using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("categoria")]
    public class Categoria
    {

        [Key]
        [Column("id_categoria")]
        public int id_categoria { get; set; }

        [Column("id_criterio")]
        public int id_criterio { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }
    }
}

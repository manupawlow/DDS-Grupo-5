using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Anual.Egresos;

namespace TP_Anual.Egresos
{
    [Table("criterio_por_item")]
    public class CriterioPorItem
    {
        [Key]
        [Column("id_criterio_por_item")]
        public int id_crit_por_item { get; set; }

        [Column("id_criterio")]
        public int id_criterio { get; set; }
        public Criterio criterio { get; set; }

        [Column("id_item")]
        public int id_item { get; set; }
        public Item item { get; set; }

        [Column("id_categoria_item")]
        public int id_categoria_item { get; set; }
        public Categoria categoria_item { get; set; }
    }
}

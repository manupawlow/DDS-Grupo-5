using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("item_por_presupuesto")]    
    public class ItemPorPresupuesto
    {
        [Key]
        [Column("id_item_por_presupuesto")]
        public int id_item_por_presupuesto { get; set; }

        [Column("id_item")]
        public int id_item { get; set; }
        public Item item { get; set; }

        [Column("id_presupuesto")]
        public int id_presupuesto { get; set; }
        public Presupuesto presupuesto { get; set; }

        [Column("valor")]
        public int valor { get; set; }
    }
}

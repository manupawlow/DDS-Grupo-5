using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("item_por_egreso")]
    public class ItemPorEgreso
    {
        [Key]
        [Column("id_item_por_egreso")]
        public int id_item_por_egreso { get; set; }

        [Column("id_item")]
        public int id_item { get; set; }
        public Item item { get; set; }

        [Column("id_egreso")]
        public int id_egreso { get; set; }
        public Egreso egreso { get; set; }

        [Column("valor")]
        public int valor { get; set; }

        [Column("cantidad")]
        public int cantidad { get; set; }


        public ItemPorEgreso(Egreso e, Item i, int c)
        {
            egreso = e;
            item = i;
            cantidad = c;
        }
    }
}

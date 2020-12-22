using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_Anual.Egresos;

namespace TP_Anual.Egresos
{
    [Table("criterio_categoria_por_item")]
    public class CriterioCategoriaPorItem
    {
        [Key]
        [Column("id_criterio_categoria_por_item")]
        public int id_criterio_categoria_por_item { get; set; }
        
        public Item item { get; set; }
        public Criterio criterio_item { get; set; }
        public Categoria categoria_item { get; set; }

        [Column("id_item")]
        public int id_item { get; set; }

        [Column("id_categoria")]
        public int id_categoria_item { get; set; }
       
        [Column("id_criterio")]
        public int id_criterio_item { get; set; }
    }
}

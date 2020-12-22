using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP_Anual.Egresos;

namespace TP_Anual.Egresos
{
    [Table("item")]
    public class Item
    {

        [Key]
        [Column("id_item")]
        public int id_item { get; set; }

        [Column("valor")]
        public int valor { get; set; }

        [Column("cantidad")]
        public int cantidad { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        public Egreso egreso { get; set; }

        public Proveedor prov { get; set; }

        public Presupuesto presupuesto { get; set; }

        public List<CriterioCategoriaPorItem> criteriosCategorias;

        [Column("id_egreso")]
        public int id_egreso { get; set; }

        [Column("id_proveedor")]
        public int id_proveedor { get; set; }

        [Column("id_presupuesto")]
        public int id_presupuesto { get; set; }


        public Item() 
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace TP_Anual.Egresos
{
    [Table("criterio")]
    public class Criterio
    {
        [Key]
        [Column("id_criterio")]
        public int id_criterio { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }
        
        [Column("jerarquia")]
        public int jerarquia { get; set; }

        //[Column("id_categoria")]
        //public int id_categoria { get; set; }

        public List<Categoria> categorias { get; set; }

        public Criterio()
        {
            categorias = new List<Categoria>();
        }
    }
}

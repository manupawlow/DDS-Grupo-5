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

        //[Column("valor")]
        //public int valor { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        public List<Presupuesto> presupuesto { get; set; }


        //public List<Criterio> criterio = new List<Criterio>();
        public List<CriterioPorItem> criteriosDeItem { get; set; }

        
        public Item() 
        {
            presupuesto = new List<Presupuesto>();
           criteriosDeItem = new List<CriterioPorItem>();
        }

    }
}

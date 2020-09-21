using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("documento_comercial")]
    public class DocumentoComercial
    {
        [Key]
        [Column("id_documento")]
        public int id_documento { get; set; }
        
        [Column("tipo")]
        public string tipo  { get; set; }

        [Column("numero")]
        public int numero { get; set; }

        /*[Column("id_egreso")]
        public int id_egreso { get; set; }
        public Egreso egreso { get; set; }

        [Column("presupuesto_id_presupuesto")]
        public int id_presupuesto { get; set; }
        public Presupuesto presupuesto { get; set; }
        */
       
    }
}

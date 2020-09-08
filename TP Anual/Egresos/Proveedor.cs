using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("proveedor")]
    public class Proveedor
    {
        [Column("id_prov")]
        public int id_prov { get; set; }

        [Column("CUIT")]
        public int CUIT { get; set; }

        [Column("razon_social")]
        public string razon_social { get; set; }

    }
}

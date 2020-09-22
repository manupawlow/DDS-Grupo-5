using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    [Table("entidad_juridica")]
    class EntidadJuridica : Organizacion
    {

        [Key]
        [Column("id_juridica")]
        public int id_juridica { get; set; }

        [Column("codigo_IGJ")]
        public int codigo_IGJ { get; set; }

        [Column("CUIT")]
        public int CUIT { get; set; }

        [Column("direccion_postal")]
        public DireccionPostal direccion_postal { get; set; }

        [Column("razon_social")]
        public string razon_social { get; set; }

        public List<EntidadBase> entidades_base { get; set; }

        public EntidadJuridica()
        {
            entidades_base = new List<EntidadBase>();
        }

    }
}

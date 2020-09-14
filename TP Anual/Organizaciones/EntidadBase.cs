using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    [Table("entidad_base")]
    class EntidadBase : Organizacion
    {
        
        [Column("descripcion")]
        public string descripcion {get; set;}

        [Column("id_juridica")]
        public int id_juridica {get; set;}

        public EntidadJuridica entidad_juridica { get; set; }


    }
}

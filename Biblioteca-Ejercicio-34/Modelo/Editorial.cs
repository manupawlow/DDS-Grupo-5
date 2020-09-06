using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Ejercicio_34.Modelo
{
    [Table("Editorial")]
    class Editorial
    {
        [Key]
        [Column("id_editorial")]
        public int id { get; set; }
        [Column("nombre")]
        public string nombre { get; set; }

    }
}

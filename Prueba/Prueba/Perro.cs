using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Prueba
{
    [Table("perros")]
    class Perro
    {

        [Key]
        [Column("id_perro")]
        public int id { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("id_dueño")]
        public int id_duenio { get; set; }

        public Persona duenio { get; set; }
    }
}

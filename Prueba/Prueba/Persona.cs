using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Prueba
{
    [Table("personas")]
    class Persona
    {
        [Key]
        [Column("id_persona")]
        public int id { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("dni")]
        public int dni { get; set; }

        public List<Perro> perros { get; set; }

    }
}

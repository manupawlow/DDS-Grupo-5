using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca_Ejercicio_34.Modelo
{
    [Table("autores")]
    class Autor
    {
        [Key]
        [Column("id_autor")]
        public int id_autor { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("fecha_nacimiento")]
        public int fecha_nacimiento { get; set; }


    }
}

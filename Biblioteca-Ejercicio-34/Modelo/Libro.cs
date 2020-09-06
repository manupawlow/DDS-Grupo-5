using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca_Ejercicio_34.Modelo
{
    [Table("libros")]
    class Libro
    {
        [Key]
        [Column("id_libro")]
        public int id { get; set; }

        [Column("anio")]
        public int anio { get; set; }
        public Autor autor { get; set; }

        [Column("id_autor")]
        public int id_autor { get; set; }

        [Column("categoria")]
        public string categoria { get; set; }

       //[Column("editorial")]
        //public Editorial editorial { get; set; }

        [Column("en_biblioteca")]
        public bool en_biblioteca { get; set; }

        [Column("en_reparacion")]
        public bool en_reparacion { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("en_prestamo")]
        public bool prestado { get; set; }

        public Libro() 
        {

            prestado = false;
            en_reparacion = false;
            en_biblioteca = true;

        }


        public void estaEnBiblioteca()
        {
            en_biblioteca = true;
        }

        public void estaPrestado()
        {
            prestado = true;
        }

        public void estaEnReparacion() 
        {
            en_reparacion = true;
        }

    }
}

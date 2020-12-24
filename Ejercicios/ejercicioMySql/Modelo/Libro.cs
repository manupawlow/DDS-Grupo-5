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

        [Column("editorial")]
        public string editorial { get; set; }

        [Column("en_biblioteca")]
        public bool en_biblioteca { get; set; }

        [Column("en_reparacion")]
        public bool en_reparacion { get; set; }

        [Column("fecha_prestamo")]
        public int fecha_prestamo { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("en_prestamo")]
        public bool prestado { get; set; }

        public Libro() 
        {
            fecha_prestamo = 0;
            prestado = false;
            en_reparacion = false;
            en_biblioteca = true;

        }


        public void ingresar_libro()
        {
            en_biblioteca = true;
        }

        public void prestar_libro(int fecha)
        {
            prestado = true;
            en_biblioteca = false;
            fecha_prestamo = fecha;
        }

        public void reparar() 
        {
            en_reparacion = true;
            en_biblioteca = false;
        }

        public bool esta_demorado(int fecha_actual) 
        {
            if (prestado)
                return fecha_actual - fecha_prestamo > 30;
            else
                return false;
        }

    }
}

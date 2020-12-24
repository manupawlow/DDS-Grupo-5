using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_Ejercicio_34.Modelo
{

    [Table("prestamos")]
    class Prestamo
    {
        [Key]
        [Column("id_prestamo")]
        public int id { get; set; }

        [Column("fecha")]
        public int fecha { get; set; }

        [Column("id_lector")]
        public int id_lector { get; set; }
        public Lector lector { get; set; }

        [Column("id_libro")]
        public int id_libro { get; set; }

        [Column("activo")]
        public int activo { get; set; }

        public Libro libro { get; set; }

        public Prestamo() 
        {
            activo = 1;
        }

        public void calcular_multa(int fecha_actual)
        {
            if (fecha_actual - fecha > 30)
                lector.multar((fecha_actual - fecha - 30) * 2);
        }

        public void libro_devuelto(int fecha_actual) 
        {
            libro.ingresar_libro();
            activo = 0;
            calcular_multa(fecha_actual);
        }


    }
}

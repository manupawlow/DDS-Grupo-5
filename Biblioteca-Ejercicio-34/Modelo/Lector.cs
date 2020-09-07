using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Biblioteca_Ejercicio_34.Modelo
{
    [Table("lectores")]
    class Lector
    {

        [Key]
        [Column("id_lector")]
        public int id { get; set; }

        [Column("dias_multado")]
        public int dias_multado { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        [Column("cant_libros")]
        public int cant_libros { get; set; }

        public List<Prestamo> prestamos { get; set; }

        public Lector()
        {
            dias_multado = 0;
            cant_libros = 0;
            prestamos = new List<Prestamo>();
        }

        public void libro_prestado(Prestamo Prestamo) 
        {
            prestamos.Add(Prestamo);
            cant_libros += 1;
        }

        public void multar(int cant_dias)
        {
            dias_multado = cant_dias;
        }

        public void devolver_libro(Prestamo Prestamo, int Fecha_actual)
        {
            cant_libros -= 1;
            Prestamo.libro_devuelto(Fecha_actual);
        }
    }
}

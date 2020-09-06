using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca_Ejercicio_34.Modelo
{
    [Table("lectores")]
    class Lector
    {

        [Key]
        [Column("id_lector")]
        public int id { get; set; }

        [Column("multado")]
        public bool multado { get; set; }

        [Column("nombre")]
        public string nombre { get; set; }

        public List<Prestamo> prestamos { get; set; }

        public Lector()
        {
            multado = false;
   
        }

        public void multar()
        {
            multado = true;
        }

        public void devolver_libro(Prestamo Prestamo, int Fecha_actual)
        {
            prestamos.RemoveAt(1);
            Prestamo.libro_devuelto(Fecha_actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Administrador_Inicio_Sesion
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("usuario_id")]
        public int id { get; set; }

        [Column("usuario_nombre")]
        public string nombre { get; set; }

        [Column("usuario_contrasenia")]
        public string contrasenia { get; set; }

        [Column("usuario_admin")]
        public bool esAdministrador { get; set; }


        public Usuario(string name, string pasword, bool type)
        {
            nombre = name;
            contrasenia = pasword;
            esAdministrador = type;
        }

    }
}
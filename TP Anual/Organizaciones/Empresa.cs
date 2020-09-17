using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Organizaciones
{
    [Table("empresa")]
    public abstract class Empresa : TipoOrganizacion
    {
        [Key]
        [Column("id_empresa")]
        public int id_empresa { get; set; }


        public Dictionary<string, float> topeVentasPorActividad;
        public Dictionary<string, int> topePersonalPorActividad;
       
        public float TopeVentasPorActividad(string actividad)
        {
            return topeVentasPorActividad[actividad];
        }
        public int TopePersonalPorActividad(string actividad)
        {
            return topePersonalPorActividad[actividad];
        }

    }
}

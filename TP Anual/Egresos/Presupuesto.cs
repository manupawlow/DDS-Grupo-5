using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("presupuesto")]
    public class Presupuesto
    {
        [Key]
        [Column("id_presupuesto")]
        public int id_presupuesto { get; set; }
        [Column("valor_total")]
        public int valor_total { get; set; }

        public List<Item> itemsDePresupuesto { get; set; }
        public DocumentoComercial documentoComercial { get; set; }
        public Proveedor proveedor { get; set; }
        public Egreso egreso { get; set; }
        
        //Agregado para ORM
        [Column("id_egreso")]
        public int id_egreso { get; set; }
        [Column("id_documento_comercial")]
        public int id_documento_comercial { get; set; }
        [Column("id_prov")]
        public int id_prov { get; set; }

        public Presupuesto()
        {
            itemsDePresupuesto = new List<Item>();
        }

        public void calcular_total()
        {
            valor_total = itemsDePresupuesto.Sum(item => item.valor * item.cantidad);
        }

        public void agregar_item(Item item)
        {
            itemsDePresupuesto.Add(item);
            valor_total = itemsDePresupuesto.Sum(items => items.valor);
        }
    }
}

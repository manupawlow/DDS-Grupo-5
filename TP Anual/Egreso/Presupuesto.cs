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

        [Column("id_prov")]
        public int id_prov { get; set; }

        public List<Item> itemsDePresupuesto { get; set; }
        public List<DocumentoComercial> documentosComerciales { get; set; }
        public Proveedor proveedor;

        public Presupuesto()
        {
            itemsDePresupuesto = new List<Item>();
            documentosComerciales = new List<DocumentoComercial>();
        }

        public void agregar_item(Item Item)
        {
            itemsDePresupuesto.Add(Item);
            valor_total = itemsDePresupuesto.Sum(items => items.valor);
        }
    }
}

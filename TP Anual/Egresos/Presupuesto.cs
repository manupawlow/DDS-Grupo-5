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
        [Column("id_presupuesto")]
        public int id_presupuesto { get; set; }

        [Column("valor_total")]
        public int valor_total { get; set; }

        [Column("id_prov")]
        public int id_prove { get; set; }

        public List<Item> itemsDePresupuesto = new List<Item>();
        public DocumentoComercial documentoComercial;
        public Proveedor proveedor;

        public void agregar_item(Item Item)
        {
            itemsDePresupuesto.Add(Item);
            valor_total = itemsDePresupuesto.Sum(items => items.valor);
        }
    }
}

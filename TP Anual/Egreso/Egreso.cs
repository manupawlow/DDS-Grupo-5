using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Anual.Egresos
{
    [Table("egreso")]
    public class Egreso
    {
        [Key]
        [Column("id_egreso")]
        public int id_egreso { get; set; }

        [Column("cant_presupuestos_requeridos")]
        public int cantPresupuestos { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }
        
        [Column("valor_total")]
        public int valorTotal { get; set; }

        [Column("id_prov")]
        public int id_prov { get; set; }
        
        [Column("id_entidad_base")]
        public int id_entidad_base  { get; set; }

        [Column("id_entidad_juridica")]
        public int id_entidad_juridica { get; set; }

        [Column("id_ingreso")]
       

        public int id_ingreso { get; set; }
        public List<DocumentoComercial> documentosComerciales { get; set; }
        public Proveedor proveedorElegido { get; set; }
        public Ingreso ingreso { get; set; }
        public List<Presupuesto> presupuestos { get; set; }
       

        public BandejaDeMensajes bandejaDeMensajes;
        public ICriterioDeSeleccion criterioDeSeleccion;
        public List<Item> items = new List<Item>();
        public MedioDePago medioDePago;
        public Presupuesto presupuestoElegido;

        
        public Egreso()
        {
            presupuestos = new List<Presupuesto>();
            documentosComerciales = new List<DocumentoComercial>();
        }
        

        public void agregarItem(Item item)
        {
            items.Add(item);
        }


        public void elegirPresupuesto(Presupuesto Presupuesto)
        {
            presupuestoElegido = Presupuesto;
            proveedorElegido = Presupuesto.proveedor;
            valorTotal = Presupuesto.valor_total;
        }


    }
}

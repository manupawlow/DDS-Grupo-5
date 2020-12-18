using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Driver;

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

        [Column("valor_total")]
        public int valorTotal { get; set; }

        [Column("descripcion")]
        public string descripcion { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }

        public BandejaDeMensajes bandejaDeMensajes;
        public ICriterioDeSeleccion criterioDeSeleccion;
        public MedioDePago medioDePago;
        public DocumentoComercial documentoComercial { get; set; }
        public Ingreso ingreso { get; set; }
        public List<Item> items { get; set; }
        public Presupuesto presupuestoElegido { get; set; }
        public ProyectoDeFinanciamiento proyecto { get; set; }
        public List<Presupuesto> presupuestos { get; set; }
        public Proveedor proveedorElegido { get; set; }


        //Agregado para ORM
        [Column("id_ingreso")]
        public int id_ingreso { get; set; }
        
        [Column("id_proyecto")]
        public int id_proyecto { get; set; }
       
        [Column("id_presupuesto_elegido")]
        public int id_presupuesto_elegido { get; set; }

        [Column("id_documento_comercial")]
        public int id_documento_comercial { get; set; }

        [Column("id_prov")]
        public int id_prov { get; set; }

        [Column("id_entidad_base")]
        public int id_entidad_base { get; set; }

        [Column("id_entidad_juridica")]
        public int id_entidad_juridica { get; set; }

        public Egreso()
        {
            items = new List<Item>();
            presupuestos = new List<Presupuesto>();
        }

        public void elegirPresupuesto(Presupuesto Presupuesto)
        {
            presupuestoElegido = Presupuesto;
            proveedorElegido = Presupuesto.proveedor;
            valorTotal = Presupuesto.valor_total;
            items = Presupuesto.itemsDePresupuesto;
        }

    }
}

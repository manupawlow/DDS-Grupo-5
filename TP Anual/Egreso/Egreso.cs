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

        public BandejaDeMensajes bandejaDeMensajes;
        public ICriterioDeSeleccion criterioDeSeleccion;
        public DocumentoComercial documentoComercial;
        public List<Item> items = new List<Item>();
        public MedioDePago medioDePago;
        public Proveedor proveedorElegido { get; set; }
        public Presupuesto presupuestoElegido;
        public List<Presupuesto> presupuestos = new List<Presupuesto>();
        public Ingreso ingreso { get; set; }

        /*
        public Egreso(DateTime Fecha, DocumentoComercial Doc, MedioDePago Medio, int cantidadDePresupuesto, BandejaDeMensajes Bandeja)
        {
            fecha = Fecha;
            documentoComercial = Doc;
            medioDePago = Medio;
            cantPresupuestos = cantidadDePresupuesto;
            bandejaDeMensajes = Bandeja;

        }
        */

        public void agregarItem(Item item)
        {
            items.Add(item);
        }

        public void agregarPresupuesto(Presupuesto Pres)
        {
           presupuestos.Add(Pres);
        }

        public void elegirPresupuesto(Presupuesto Presupuesto)
        {
            presupuestoElegido = Presupuesto;
            proveedorElegido = Presupuesto.proveedor;
            valorTotal = Presupuesto.valor_total;
        }


    }
}

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

        public BandejaDeMensajes bandejaDeMensajes;

        [Column("cant_presupuestos_requeridos")]
        public int cantPresupuestos { get; set; }

        public ICriterioDeSeleccion criterioDeSeleccion;
        public DocumentoComercial documentoComercial { get; set; }
        [Column("id_documento_comercial")]
        public int id_documento_comercial { get; set; }

        [Column("fecha")]
        public DateTime fecha { get; set; }

        public Ingreso ingreso { get; set; }
        [Column("id_ingreso")]
        public int id_ingreso { get; set; }

        public List<ItemPorEgreso> items { get; set; }

        public MedioDePago medioDePago;

        public Presupuesto presupuestoElegido;

        [Column("id_proyecto")]
        public int id_proyecto { get; set; }
        public ProyectoDeFinanciamiento proyecto { get; set; }

        public List<Presupuesto> presupuestos { get; set; }

        public Proveedor proveedorElegido { get; set; }
        [Column("id_prov")]
        public int id_prov { get; set; }

        [Column("valor_total")]
        public int valorTotal { get; set; }

        public string descripcion;

        //Agregado para ORM
        [Column("id_entidad_base")]
        public int id_entidad_base { get; set; }

        [Column("id_entidad_juridica")]
        public int id_entidad_juridica { get; set; }

        public Egreso()
        {
            items = new List<ItemPorEgreso>();
            presupuestos = new List<Presupuesto>();
        }

        public Egreso(int _cantidad, BandejaDeMensajes _bandeja)
        {
            items = new List<ItemPorEgreso>();
            presupuestos = new List<Presupuesto>();
            cantPresupuestos = _cantidad;
            fecha = DateTime.Today;
            bandejaDeMensajes = _bandeja;
        }

        public void elegirPresupuesto(Presupuesto Presupuesto)
        {
            presupuestoElegido = Presupuesto;
            proveedorElegido = Presupuesto.proveedor;
            valorTotal = Presupuesto.valor_total;
        }

        public string mostrarBandejaDeMensajes()
        {
            return MongoDB.getInstancia().mostrarBandejaDeMensajesDeEgreso(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Anual.Egresos
{
    public class Egreso
    {
        public BandejaDeMensajes bandejaDeMensajes;
        public int cantPresupuestos;
        public ICriterioDeSeleccion criterioDeSeleccion;
        public DocumentoComercial documentoComercial;
        private DateTime fecha;
        public List<Item> items = new List<Item>();
        private MedioDePago medioDePago;
        public Proveedor proveedorElegido;
        public Presupuesto presupuestoElegido;
        public List<Presupuesto> presupuestos = new List<Presupuesto>();
        public float valorTotal;


        public Egreso(DateTime Fecha, DocumentoComercial Doc, MedioDePago Medio, int cantidadDePresupuesto, BandejaDeMensajes Bandeja)
        {
            fecha = Fecha;
            documentoComercial = Doc;
            medioDePago = Medio;
            cantPresupuestos = cantidadDePresupuesto;
            bandejaDeMensajes = Bandeja;

        }

        public void agregarItem(Item item)
        {
            items.Add(item);
        }

        public void agregarPresupuesto(Presupuesto Pres)
        {
           presupuestos.Add(Pres);
        }


        public void elegirCriterioDeSeleccion(ICriterioDeSeleccion criterioDeSelec)
        {
            criterioDeSeleccion = criterioDeSelec;

        }

        public void elegirPresupuesto(Presupuesto Presupuesto)
        {
            presupuestoElegido = Presupuesto;
            proveedorElegido = Presupuesto.proveedor;
            valorTotal = Presupuesto.valorTotal;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TP_ANUAL_DDS.Egresos
{
    public class Egreso
    {
        private DocumentoComercial documentoComercial;
        private DateTime fecha;
        public List<Item> items = new List<Item>();
        private MedioDePago medioDePago;
        public List<Proveedor> proveedores = new List<Proveedor>();
        public Proveedor proveedorElegido;
        public float valorTotal;
        public int cantPresupuestos;
        //public string revisorDeCompra;
        public ICriterioDeSeleccion criterioDeSeleccion;
        public BandejaDeMensajes bandejaDeMensajes;

        public Egreso(DateTime Fecha, DocumentoComercial Doc, MedioDePago Medio, int cantidadDePresupuesto, Proveedor proveedor, BandejaDeMensajes Bandeja)
        {
            fecha = Fecha;
            documentoComercial = Doc;
            medioDePago = Medio;
            cantPresupuestos = cantidadDePresupuesto;
            proveedorElegido = proveedor;
            bandejaDeMensajes = Bandeja;

        }
        
        public void agregarItem(Item item) 
        {
            items.Add(item);
        }
        public void agregarProveedor(Proveedor Prov)
        {
            proveedores.Add(Prov);
        }

        /*public void calcularValorTotal()
        {
            valorTotal = items.Sum(item => item.valor);

        }*/

        public void definirCriterioDeSeleccion(ICriterioDeSeleccion criterioDeSelec)
        {
            criterioDeSeleccion = criterioDeSelec;

        }

        public Proveedor Criterio(List<Proveedor> provs)
        {
            return criterioDeSeleccion.Criterio(provs);
        }

    }
}

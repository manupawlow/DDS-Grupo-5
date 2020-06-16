using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TP_ANUAL_DDS.Egresos
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
        public List<Proveedor> proveedores = new List<Proveedor>();
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

        public void agregarProveedor(Proveedor Prov)
        {
            proveedores.Add(Prov);
        }

        public void calcularValorTotal()
        {
            valorTotal = proveedorElegido.valorSegunEgreso();

        }

        public Proveedor Criterio(List<Proveedor> provs)
        {
            return criterioDeSeleccion.Criterio(provs);
        }

        public void definirCriterioDeSeleccion(ICriterioDeSeleccion criterioDeSelec)
        {
            criterioDeSeleccion = criterioDeSelec;

        }

        public void elegirProveedor(Proveedor proveedor)
        {
            proveedorElegido = proveedor;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Anual.DAOs;
using TP_Anual.Administrador_Inicio_Sesion;
using TP_Anual.Egresos;

namespace TpAnualWeb.Controllers
{
    public class EgresoController : Controller
    {
        // GET: Egreso
        public ActionResult Egreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarEgreso(string descripcion = "", int cantPresup = -1)
        {
            if (descripcion == "" || cantPresup == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                if (cantPresup < 0)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "La cantidad de presupuestos no puede ser negativa";

                    return View("Mostrar");
                }
                else
                {
                    var revisor = UsuarioDAO.getInstancia().getUsuarioByUserName(Session["UserName"].ToString()).nombre;
                    EgresoDAO.getInstancia().cargarEgreso(descripcion, revisor, cantPresup);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = "Se cargo el egreso correctamente";

                    return View("Mostrar");
                }

            }

        }

        [HttpPost]
        public ActionResult AgregarPresupuesto(int id_egreso = -1, string CUIT = "", FormCollection inputs = null)
        {
            if (id_egreso == -1 || CUIT == "" || inputs["nuevoItemPresupuesto"] == null || inputs["cantidad"] == null || inputs["precio"] == null)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
                var proveedor = ProveedorDAO.getInstancia().getProveedorByCUIT(CUIT);

                if (egreso == null || proveedor == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");
                }
                else
                {
                    var items = inputs["nuevoItemPresupuesto"].Split(',');
                    var cantidades = inputs["cantidad"].Split(',');
                    var precios = inputs["precio"].Split(',');

                    PresupuestoDAO.getInstancia().cargarPresupuesto(id_egreso, CUIT, items, cantidades, precios);

                    return View("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult AsignarCriterio(string item_desc = "", string criterio = "", string categoria = "")
        {

            if (item_desc == "" || criterio == "" || categoria == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var item = ItemDAO.getInstancia().getItemByDescripcion(item_desc);
                var cri = CriterioCategoriaDAO.getInstancia().getCriterioByDescripcion(criterio);
                var cat = CriterioCategoriaDAO.getInstancia().getCategoriaByDescripcion(categoria);

                if (item == null || cri == null || cat == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");

                }
                else
                {
                    var nuevo = new Criterio();
                    //nuevo.item = item;
                    //nuevo.criterio = cri;
                    //nuevo.categoria_item = cat;

                    CriterioCategoriaDAO.getInstancia().AddCriterioPorItem(nuevo);

                    return View("Index");

                }
            }
        }

        [HttpPost]
        public ActionResult ElegirPresupuesto(int id_egreso = -1, int id_presupuesto = -1)
        {
            if (id_egreso == -1 || id_presupuesto == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
                var presupuesto = PresupuestoDAO.getInstancia().getPresupuestoById(id_presupuesto);

                if (egreso == null || presupuesto == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");
                }
                else
                {
                    PresupuestoDAO.getInstancia().elegirPresupuesto(id_egreso, id_presupuesto);

                    return View("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult ValidarEgreso(int id_egreso = -1)
        {
            if (id_egreso == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un egreso";

                return View("Mostrar");
            }
            else
            {
                var usuario = UsuarioDAO.getInstancia().getUsuarioByUserName(Session["UserName"].ToString()).id;
                var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
                TP_Anual.MongoDB.getInstancia().agregarBandejaAEgresoEnCasoQueNoLaTengaAsignada(egreso);
                var revisor = egreso.bandejaDeMensajes.revisor.id;

                if (usuario != revisor)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Solo el usuario revisor del egreso puede validarlo";

                    return View("Mostrar");
                }
                else
                {
                    try
                    {
                        ViewBag.mostrar = "VALIDACION";
                        if (EgresoDAO.getInstancia().validarEgreso(id_egreso))
                        {
                            ViewBag.validacion = "El egreso fue validado correctamente, para ver resultados ver bandeja de mensajes";
                        }
                        else
                        {
                            ViewBag.validacion = "El egreso fallo la validacion, para ver resultados ver bandeja de mensajes";
                        }

                    }
                    catch (InvalidOperationException)
                    {
                        ViewBag.mostrar = "ERROR";
                        ViewBag.error = "No existe el egreso ingresado";
                    }

                    return View("Mostrar");
                }

            }

        }

        [HttpPost]
        public ActionResult BandejaDeMensajesDeEgreso(int id_egreso = -1)
        {

            if (id_egreso == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un egreso";

                return View("Mostrar");
            }
            else
            {
                var usuario = UsuarioDAO.getInstancia().getUsuarioByUserName(Session["UserName"].ToString()).id;
                var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
                TP_Anual.MongoDB.getInstancia().agregarBandejaAEgresoEnCasoQueNoLaTengaAsignada(egreso);
                var revisor = egreso.bandejaDeMensajes.revisor.id;

                if (usuario != revisor)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Solo el usuario que creo el egreso puede ver la bandeja de mensajes";

                    return View("Mostrar");
                }
                else
                {
                    if (egreso.bandejaDeMensajes.mensajes == null)
                    {
                        ViewBag.mostrar = "ERROR";
                        ViewBag.error = "El egreso aun no fue validado";

                        return View("Mostrar");
                    }
                    else
                    {
                        if (egreso != null)
                        {
                            ViewBag.mostrar = "BANDEJA DE MENSAJES";
                            ViewBag.bandeja = egreso.bandejaDeMensajes;
                            ViewBag.mensajes = TP_Anual.MongoDB.getInstancia().mostrarBandejaDeMensajesDeEgreso(egreso);

                            return View("Mostrar");
                        }
                        else
                        {
                            ViewBag.mostrar = "ERROR";
                            ViewBag.error = "No existe el egreso";

                            return View("Mostrar");
                        }

                    }
                }
            }
        }

        /*
        [HttpPost]
        public ActionResult MostrarPresupuestos()
        {
            ViewBag.mostrar = "PRESUPUESTOS";
            ViewBag.presupuestos = PresupuestoDAO.getInstancia().getAllPresupuesto();
            return View("Mostrar");
        }

        [HttpPost]
        public ActionResult MostrarPresupuestoConItems(int id_presupuesto = -1)
        {
            if (id_presupuesto == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un presupuesto";

                return View("Mostrar");
            }
            else
            {
                var presupuesto = PresupuestoDAO.getInstancia().getPresupuestoById(id_presupuesto);

                if (presupuesto == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "No existe el presupuesto ingresado";

                    return View("Mostrar");
                }
                else
                {
                    ViewBag.mostrar = "PRESUPUESTO";
                    ViewBag.presupuesto = PresupuestoDAO.getInstancia().getPresupuestoById(id_presupuesto);
                    ViewBag.items = ItemDAO.getInstancia().getItemsPorPresupuesto(id_presupuesto);

                    return View("Mostrar");
                }

            }

        }

        [HttpPost]
        public ActionResult MostrarPresupuestosPorEgreso(int id_egreso = -1)
        {

            if (id_egreso == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un egreso";

                return View("Mostrar");
            }
            else
            {
                var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);

                if (egreso == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "No existe el egreso ingresado";

                    return View("Mostrar");
                }
                else
                {
                    var presupuestos = EgresoDAO.getInstancia().getEgresoById(id_egreso).presupuestos.Count;

                    if (presupuestos == 0)
                    {
                        ViewBag.mostrar = "ERROR";
                        ViewBag.error = "El egreso no tiene presupuestos asociados";

                        return View("Mostrar");
                    }
                    else
                    {
                        ViewBag.mostrar = "PRESUPUESTOS DE EGRESO";
                        ViewBag.presupuestos = EgresoDAO.getInstancia().getEgresoById(id_egreso).presupuestos;
                        ViewBag.msg = id_egreso;

                        return View("Mostrar");
                    }
                }
            }

        }
        */


    }
}
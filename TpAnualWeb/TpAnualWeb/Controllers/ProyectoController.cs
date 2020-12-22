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
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Proyecto()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CargarProyecto(int monto = -1, int cant_presupuestos = -1, string usuario = "")
        {
            if (monto == -1 || cant_presupuestos == -1 || usuario == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                if (UsuarioDAO.getInstancia().getUsuarioByUserName(usuario) == null || monto < 0)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");
                }
                else
                {
                    var proyecto = ProyectoDAO.getInstancia().cargarProyecto(cant_presupuestos, monto, usuario);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = ($"Se creo el proyecto de id: {proyecto.id} correctamente!");

                    return View("Mostrar");

                }
            }

        }

        [HttpPost]
        public ActionResult VincularIngresoConProyecto(int id_ingreso = -1, int id_proyecto = -1)
        {
            if (id_ingreso == -1 || id_proyecto == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var ingreso = IngresoDAO.getInstancia().getIngresoById(id_ingreso);
                var proyecto = ProyectoDAO.getInstancia().getProyectoById(id_proyecto);

                if (ingreso == null || proyecto == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");
                }
                else
                {
                    ProyectoDAO.getInstancia().vincularIngresoConProyecto(id_proyecto, id_ingreso);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = ($"Se vinculo el ingreso {ingreso.descripcion} con el proyecto de id: {proyecto.id} correctamente!");

                    return View("Mostrar");

                }

            }

        }

        [HttpPost]
        public ActionResult VincularEgresoConProyecto(int id_egreso = -1, int id_proyecto = -1)
        {
            if (id_egreso == -1 || id_proyecto == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
                var proyecto = ProyectoDAO.getInstancia().getProyectoById(id_proyecto);

                if (egreso == null || proyecto == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");
                }
                else
                {
                    ProyectoDAO.getInstancia().vincularEgresoConProyecto(id_proyecto, id_egreso);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = ($"Se vinculo el egreso {egreso.descripcion} con el proyecto de id: {proyecto.id} correctamente!");

                    return View("Mostrar");
                }
            }
        }

        [HttpPost]
        public ActionResult BajaProyecto(int id_proyecto = -1)
        {

            if (id_proyecto == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un proyecto";

                return View("Mostrar");
            }
            else
            {
                var proyecto = ProyectoDAO.getInstancia().getProyectoById(id_proyecto);

                if (proyecto == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "No existe el proyecto ingresado";

                    return View("Mostrar");
                }
                else
                {
                    ProyectoDAO.getInstancia().bajaProyecto(id_proyecto);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = ($"Se elimino el proyecto de id: {proyecto.id} correctamente!");

                    return View("Mostrar");
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Anual.Egresos;
using TP_Anual.DAOs;

namespace TpAnualWeb.Controllers
{
    public class CriterioCategoriaController : Controller
    {
        // GET: CriterioCategoria
        public ActionResult CriteriosCategorias()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarCriterio(string descripcion = "", int jerarquia = -1)
        {
            if (descripcion == "" || jerarquia == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var nuevo = new Criterio();
                nuevo.descripcion = descripcion;
                nuevo.jerarquia = jerarquia;

                CriterioCategoriaDAO.getInstancia().AddCriterio(nuevo);

                ViewBag.mostrar = "SUCCESS";
                ViewBag.succes = "Se cargo el criterio correctamente";

                return View("Mostrar");

            }

        }

        [HttpPost]
        public ActionResult CargarCategoriaAcriterio(string descripcionCat = "", string descripcionCrit = "")
        {
            if (descripcionCat == "" || descripcionCrit == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var critero = CriterioCategoriaDAO.getInstancia().getCriterioByDescripcion(descripcionCrit);

                if (critero == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "No existe el criterio ingresado";

                    return View("Mostrar");
                }
                else
                {
                    var nuevo = new Categoria();
                    nuevo.descripcion = descripcionCat;

                    var criterio = CriterioCategoriaDAO.getInstancia().getCriterioByDescripcion(descripcionCrit);
                    nuevo.criterio = criterio;

                    CriterioCategoriaDAO.getInstancia().AddCategoria(nuevo);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.succes = "Se agrego la categoria " + nuevo.descripcion + " al criterio " + criterio.descripcion + ".";

                    return View("Mostrar");
                }
            }
        }


    }
}
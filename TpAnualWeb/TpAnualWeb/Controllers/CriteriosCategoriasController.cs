using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Anual.Egresos;
using TP_Anual.DAOs;

namespace TpAnualWeb.Controllers
{
    public class CriteriosCategoriasController : Controller
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
                ViewBag.success = "Se cargo el criterio " + nuevo.descripcion + " correctamente!";

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
                    ViewBag.success = "Se agrego la categoria " + nuevo.descripcion + " al criterio " + criterio.descripcion + "!";

                    return View("Mostrar");
                }
            }
        }

        [HttpPost]
        public ActionResult AsignarCategoria(string item_desc = "", string categoria = "")
        {

            if (item_desc == "" || categoria == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var item = ItemDAO.getInstancia().getItemByDescripcion(item_desc);
                var cat = CriterioCategoriaDAO.getInstancia().getCategoriaByDescripcion(categoria);
                var cri = CriterioCategoriaDAO.getInstancia().getCriterioByID(cat.id_criterio);

                if (item == null || cat == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");

                }
                else
                {

                    ItemDAO.getInstancia().AgregarCriterioItem(item, cat, cri);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = ($"Se ha asociado la categoria {cat.descripcion} al item {item.descripcion}");

                    return View("Mostrar");

                }
            }
        }


    }
}
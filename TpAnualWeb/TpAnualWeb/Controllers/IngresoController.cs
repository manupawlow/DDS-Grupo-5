using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Anual.DAOs;
using TP_Anual.Egresos;

namespace TpAnualWeb.Controllers
{
    public class IngresoController : Controller
    {
        // GET: Ingreso
        public ActionResult Ingreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarIngreso(string descripcion = "", int total = -1)
        {
            if (total == -1 || descripcion == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                if (total < 0)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "El total debe ser mayor que 0";

                    return View("Mostrar");
                }
                else
                {
                    Ingreso nuevo = new Ingreso(descripcion, total);
                    var ingreso = IngresoDAO.getInstancia().Add(nuevo);

                    ViewBag.mostrar = "SUCCESS";
                    ViewBag.success = ($"Se creo el ingreso {ingreso.descripcion} de id: {ingreso.id_ingreso} correctamente!");

                    return View("Mostrar");
                }
            }
        }


        [HttpPost]
        public ActionResult FechaPrimerEgreso(string id_egresos, string id_ingresos)
        {

            var egresos = id_egresos.Split('-');
            var ingresos = id_ingresos.Split('-');
            var a = IngresoDAO.getInstancia().asociarFechaPrimerEgreso(egresos, ingresos);
            if (a)
            {
                ViewBag.mostrar = "SUCCESS";
                ViewBag.success = ($"Se realizo la asociacion correctamente!");

                return View("Mostrar");
            }
            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Los datos ingresados no son validos";

                return View("Mostrar");
            }
        }

        [HttpPost]
        public ActionResult ValorPrimerEgreso(string id_egresos, string id_ingresos)
        {
            var egresos = id_egresos.Split('-');
            var ingresos = id_ingresos.Split('-');

            if (IngresoDAO.getInstancia().asociarValorPrimerEgreso(egresos, ingresos))
            {
                ViewBag.mostrar = "SUCCESS";
                ViewBag.success = ($"Se realizo la asociacion correctamente!");

                return View("Mostrar");
            }
            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Los datos ingresados no son validos";

                return View("Mostrar");
            }

        }

        [HttpPost]
        public ActionResult ValorPrimerIngreso(string id_egresos, string id_ingresos)
        {
            var egresos = id_egresos.Split('-');
            var ingresos = id_ingresos.Split('-');

            if (IngresoDAO.getInstancia().asociarValorPrimerIngreso(egresos, ingresos))
            {
                ViewBag.mostrar = "SUCCESS";
                ViewBag.success = ($"Se realizo la asociacion correctamente!");

                return View("Mostrar");
            }
            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Los datos ingresados no son validos";

                return View("Mostrar");
            }
        }


    }
}
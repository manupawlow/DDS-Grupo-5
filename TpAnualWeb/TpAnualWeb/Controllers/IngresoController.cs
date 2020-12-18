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
        public ActionResult Index()
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
                    IngresoDAO.getInstancia().Add(nuevo);

                    return View("Index");
                }
            }
        }


        [HttpPost]
        public ActionResult FechaPrimerEgreso()
        {
            IngresoDAO.getInstancia().asociarFechaPrimerEgreso();
            return View("Index");
        }

        [HttpPost]
        public ActionResult ValorPrimerEgreso()
        {
            IngresoDAO.getInstancia().asociarValorPrimerEgreso();
            return View("Index");
        }

        [HttpPost]
        public ActionResult ValorPrimerIngreso()
        {
            IngresoDAO.getInstancia().asociarValorPrimerIngreso();
            return View("Index");
        }


    }
}
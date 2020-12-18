using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Anual.DAOs;
using TP_Anual.Egresos;

namespace TpAnualWeb.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarProveedor(string razon = "", string CUIT = "")
        {
            if (razon == "" || CUIT == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                Proveedor nuevo = new Proveedor();
                nuevo.CUIT = CUIT;
                nuevo.razon_social = razon;
                ProveedorDAO.getInstancia().Add(nuevo);

                return View("Index");
            }

        }

    }
}
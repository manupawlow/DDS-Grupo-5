using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using TP_Anual;
using TP_Anual.DAOs;
using TP_Anual.Administrador_Inicio_Sesion;
using TP_Anual.Egresos;

namespace TpAnualWeb.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        #region Egresos

        [HttpPost]
        public JsonResult BuscarEgreso([FromBody] JsonEgreso jsonEgreso)
        {
            var egreso = EgresoDAO.getInstancia().getEgresoById(jsonEgreso.id_egreso);

            return Json(JsonConvert.SerializeObject(egreso));
        }


        [HttpPost]
        public ActionResult CargarEgreso(string revisor, int cantPresup, FormCollection inputs)
        {
            Egreso nuevo = new Egreso();
            nuevo.cantPresupuestos = cantPresup;
            nuevo.fecha = System.DateTime.Now;

            var user = UsuarioDAO.getInstancia().getUsuarioByUserName(revisor);
            nuevo.bandejaDeMensajes = new BandejaDeMensajes(user);
            
            var items = inputs["nuevoItem"].Split(',');
            var cantidades = inputs["cantidad"].Split(',');

            for (int i=0; i<items.Length; i++)
            {
                var item = ItemDAO.getInstancia().getItemByDescripcion(items[i]);
                ItemDAO.getInstancia().AddItemPorEgreso( new ItemPorEgreso(nuevo, item, Int32.Parse(cantidades[i])) );
            }

            EgresoDAO.getInstancia().Add(nuevo);
            return View("Index");
        }

        [HttpPost]
        public ActionResult MostrarEgresos()
        {
            ViewBag.mostrar = "EGRESOS";
            ViewBag.egresos = EgresoDAO.getInstancia().getAllEgreso();
            return View("Mostrar");
        }

        [HttpPost]
        public ActionResult BandejaDeMensajesDeEgreso(int id_egreso)
        {
            var egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
            ViewBag.mostrar = "BANDEJA DE MENSAJES";

            ViewBag.msg = "No existe el egreso";
            if (Session["UserName"].ToString() == egreso.bandejaDeMensajes.revisor.nombre)
                ViewBag.msg = "No esta configurado como revisor de la bandeja de mensajes";

            ViewBag.bandeja = egreso.bandejaDeMensajes;

            return View("Mostrar");
        }
        #endregion

        #region Ingresos

        [HttpPost]
        public JsonResult CargarIngreso([FromBody] JsonIngreso jsonIngreso)
        {
            Ingreso nuevo = new Ingreso(jsonIngreso.descripcion, jsonIngreso.total);
            nuevo.fecha = System.DateTime.Now;
            IngresoDAO.getInstancia().Add(nuevo);

            return Json(JsonConvert.SerializeObject(nuevo));
        }

        [HttpPost]
        public JsonResult BuscarIngreso([FromBody] JsonEgreso jsonEgreso)
        {
            var egreso = EgresoDAO.getInstancia().getEgresoById(jsonEgreso.id_egreso);
            return Json(JsonConvert.SerializeObject(egreso));
        }

        [HttpPost]
        public ActionResult MostrarIngresos()
        {
            ViewBag.mostrar = "INGRESOS";
            ViewBag.ingresos = IngresoDAO.getInstancia().getAllIngreso();
            return View("Mostrar");
        }
        #endregion

        #region Presupuestos
        [HttpPost]
        public ActionResult AgregarPresupuesto(int id_egreso, string CUIT, FormCollection inputs)
        {
            //TODO: checkear que exista el proveedro y el egreso antes de cargarlo a la BD

            Presupuesto nuevo = new Presupuesto();
            nuevo.egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
            nuevo.proveedor = ProveedorDAO.getInstancia().getProveedorByCUIT(CUIT);

            var items = inputs["nuevoItemPresupuesto"].Split(',');
            var cantidades = inputs["cantidad"].Split(',');
            var precios = inputs["precio"].Split(',');

            for (int i = 0; i < items.Length; i++)
            {
                var item = ItemDAO.getInstancia().getItemByDescripcion(items[i]);
                ItemDAO.getInstancia().AddItemPorPresupuesto(new ItemPorPresupuesto(nuevo, item, Int32.Parse(cantidades[i]), Int32.Parse(precios[i]) ) );
            }

            PresupuestoDAO.getInstancia().Add(nuevo);
            return View("Index");
        }

        [HttpPost]
        public JsonResult RegistrarProveedor([FromBody] JsonProveedor jsonProv)
        {
            Proveedor nuevo = new Proveedor();
            nuevo.CUIT = jsonProv.CUIT;
            nuevo.razon_social = jsonProv.razon;
            ProveedorDAO.getInstancia().Add(nuevo);

            return Json(JsonConvert.SerializeObject(nuevo));
        }

        #endregion

        #region Criterios y Categorias

        [HttpPost]
        public JsonResult AsignarCriterio([FromBody] JsonItem jsonItem)
        {
            var item = ItemDAO.getInstancia().getItemByDescripcion(jsonItem.descripcion);
            var criterio = CriterioCategoriaDAO.getInstancia().getCriterioByDescripcion(jsonItem.criterio);
            var categoria = CriterioCategoriaDAO.getInstancia().getCategoriaByDescripcion(jsonItem.categoria);

            //TODO: si no existe el item que notifique, si no existe criterio o categoria que la cree

            var nuevo = new CriterioPorItem();
            nuevo.item = item;
            nuevo.criterio = criterio;
            nuevo.categoria_item = categoria;

            CriterioCategoriaDAO.getInstancia().AddCriterioPorItem(nuevo);

            return Json(JsonConvert.SerializeObject(nuevo));
        }


        #endregion

        #region Usuarios
        #endregion

        #region Login/Register
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginTry(string usuario, string contrasenia)
        {
            var obj = UsuarioDAO.getInstancia().getUsuarioByUserName(usuario);
            if (obj != null && obj.contrasenia == contrasenia)
            {
                Session["UserID"] = obj.id.ToString();
                Session["UserName"] = obj.nombre;
                return RedirectToAction("UserDashBoard");
            }
            else
                return View("Login");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
                return View("Index");
            else
                return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterTry(string username, string password, bool esAdmin)
        {
            if (UsuarioDAO.getInstancia().getUsuarioByUserName(username) != null)
                ViewBag.msg = "Ya existe un usuario con ese nombre";
            else if( !Validador.validarContrasenia(password) )
                ViewBag.msg = "Esa contraseña es insegura, intentelo denuevo";
            else
                UsuarioDAO.getInstancia().Add(new Usuario(username, password, esAdmin));

            return View("Login");
        }

        #endregion

        //------------------------------------------------------------------------------------

        #region JsonClass
        public class JsonProveedor
        {
            public int id { get; set; }
            public string CUIT { get; set; }
            public string razon { get; set; }
        }

        public class JsonItem
        {
            public int id { get; set; }
            public string descripcion { get; set; }
            public string criterio { get; set; }
            public string categoria { get; set; }
        }

        public class JsonEgreso
        {
            public int id_egreso { get; set; }
            public int cantPresupuestos { get; set; }
            //public List<ItemPorEgreso> items { get; set; }
            //public DateTime fecha { get; set; }
        }

        public class JsonIngreso
        {
            public int id { get; set; }
            public int total { get; set; }
            public string descripcion { get; set; }
            public DateTime fecha { get; set; }
        }


        #endregion

    }
}
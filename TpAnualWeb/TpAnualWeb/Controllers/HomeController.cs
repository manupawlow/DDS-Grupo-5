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

        //[HttpPost]
        //public JsonResult BuscarEgreso([FromBody] JsonEgreso jsonEgreso)
        //{
        //    var egreso = EgresoDAO.getInstancia().getEgresoById(jsonEgreso.id_egreso);

        //    return Json(JsonConvert.SerializeObject(egreso));
        //}

        [HttpPost]
        public ActionResult BuscarEgreso(int id_egreso)
        {
            ViewBag.mostrar = "EGRESO";
            ViewBag.egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
            ViewBag.items = ItemDAO.getInstancia().getItemsDeEgreso(id_egreso);
            return View("Mostrar");
        }


        [HttpPost]
        public ActionResult CargarEgreso(string descripcion, string revisor, int cantPresup, FormCollection inputs = null)
        {
            if(inputs["nuevoItem"] != null || inputs["cantidad"] != null)
            {
                var items = inputs["nuevoItem"].Split(',');
                var cantidades = inputs["cantidad"].Split(',');

                //TODO: Siempre crea un nuevo item en la BD, hacer que se fije si ya existe ese item

                EgresoDAO.getInstancia().cargarEgreso(descripcion, revisor, cantPresup, items, cantidades);
            }
            else
            {
                EgresoDAO.getInstancia().cargarEgreso(descripcion, revisor, cantPresup);
            }

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

            //ViewBag.msg = "No existe el egreso";

            //TODO: ver como agarrar la bandeja de mensajes de un egreso con genaro
            //if (Session["UserName"].ToString() != egreso.bandejaDeMensajes.revisor.nombre)
            //    ViewBag.msg = "No esta configurado como revisor de la bandeja de mensajes";

            ViewBag.bandeja = egreso.bandejaDeMensajes;

            ViewBag.mensajes = EgresoDAO.getInstancia().mostrarBandejaDeMensajes(egreso);

            return View("Mostrar");
        }

        [HttpPost]
        public ActionResult ValidarEgreso(int id_egreso)
        {
            EgresoDAO.getInstancia().validarEgreso(id_egreso);

            return View("Index");
        }
        #endregion

        #region Ingresos

        [HttpPost]
        public ActionResult CargarIngreso(string descripcion, int total)
        {
            Ingreso nuevo = new Ingreso(descripcion, total);

            IngresoDAO.getInstancia().Add(nuevo);

            return View("Index");
        }

        [HttpPost]
        public ActionResult BuscarIngreso(int id_ingreso)
        {
            ViewBag.mostrar = "INGRESO";
            ViewBag.ingreso = IngresoDAO.getInstancia().getIngresoById(id_ingreso);
            return View("Mostrar");
        }

        [HttpPost]
        public ActionResult MostrarIngresos()
        {
            ViewBag.mostrar = "INGRESOS";
            ViewBag.ingresos = IngresoDAO.getInstancia().getAllIngreso();
            return View("Mostrar");
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


        #endregion

        #region Presupuestos

        [HttpPost]
        public ActionResult AgregarPresupuesto(int id_egreso, string CUIT, FormCollection inputs)
        {
            //TODO: checkear que exista el proveedro y el egreso antes de cargarlo a la BD
            //ViewBag.notificar = "No existe el egreso con ese id";


            var items = inputs["nuevoItemPresupuesto"].Split(',');
            var cantidades = inputs["cantidad"].Split(',');
            var precios = inputs["precio"].Split(',');


            PresupuestoDAO.getInstancia().cargarPresupuesto(id_egreso, CUIT, items, cantidades, precios);

            return View("Index");
        }

        [HttpPost]
        public ActionResult CargarProveedor(string razon, string CUIT)
        {
            Proveedor nuevo = new Proveedor();
            nuevo.CUIT = CUIT;
            nuevo.razon_social = razon;
            ProveedorDAO.getInstancia().Add(nuevo);


            return View("Index");
        }

        [HttpPost]
        public ActionResult MostrarPresupuestosDeEgreso(int id_egreso)
        {
            ViewBag.mostrar = "PRESUPUESTOS DE EGRESO";
            var a = EgresoDAO.getInstancia().getEgresoById(id_egreso).presupuestos;
            ViewBag.presupuestos = a;
            ViewBag.msg = id_egreso;
            return View("Mostrar");
        }

        [HttpPost]
        public ActionResult ElegirPresupuesto(int id_egreso, int id_presupuesto)
        {
            PresupuestoDAO.getInstancia().elegirPresupuesto(id_egreso, id_presupuesto);

            return View("Index");
        }

        #endregion

        #region Proyectos

        [HttpPost]
        public ActionResult CargarProyecto(int monto, int cant_presupuestos, string usuario)
        {
            ProyectoDAO.getInstancia().cargarProyecto(cant_presupuestos, monto, usuario);

            return View("Index");
        }

        [HttpPost]
        public ActionResult VincularIngresoConProyecto(int id_ingreso, int id_proyecto)
        {
            ProyectoDAO.getInstancia().vincularIngresoConProyecto(id_proyecto, id_ingreso);

            return View("Index");
        }

        [HttpPost]
        public ActionResult VincularEgresoConProyecto(int id_egreso, int id_proyecto)
        {
            ProyectoDAO.getInstancia().vincularEgresoConProyecto(id_proyecto, id_egreso);

            return View("Index");
        }

        [HttpPost]
        public ActionResult BajaProyecto(int id_proyecto)
        {
            ProyectoDAO.getInstancia().bajaProyecto(id_proyecto);

            return View("Index");
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

        [HttpPost]
        public ActionResult CargarCriterio(string descripcion, int jerarquia)
        {
            var nuevo = new Criterio();
            nuevo.descripcion = descripcion;
            nuevo.jerarquia = jerarquia;

            CriterioCategoriaDAO.getInstancia().AddCriterio(nuevo);

            return View("Index");
        }

        [HttpPost]
        public ActionResult CargarCategoria(string descripcionCat, string descripcionCrit)
        {
            var nuevo = new Categoria();
            nuevo.descripcion = descripcionCat;

            var criterio = CriterioCategoriaDAO.getInstancia().getCriterioByDescripcion(descripcionCrit);
            nuevo.criterio = criterio;

            CriterioCategoriaDAO.getInstancia().AddCategoria(nuevo);

            return View("Index");
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
        public ActionResult RegisterTry(string username, string password)// bool esAdmin)
        {
            /*if (UsuarioDAO.getInstancia().getUsuarioByUserName(username) != null)
                ViewBag.msg = "Ya existe un usuario con ese nombre";
            else if (!Validador.validarContrasenia(password))
            {
                ViewBag.msg = "Esa contraseña es insegura, intentelo denuevo";
                return View("Register");
            }
            else*/
            UsuarioDAO.getInstancia().Add(new Usuario(username, password, true));//, esAdmin));

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
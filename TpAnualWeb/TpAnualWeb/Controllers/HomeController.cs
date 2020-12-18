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
        public ActionResult CargarValidar()
        {
            return View("Egreso");
        }

        [HttpPost]
        public ActionResult BuscarEgreso(int id_egreso = -1)
        {
            if (id_egreso == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un egreso";

                return View("Mostrar");
            }
            else
            {
                ViewBag.mostrar = "EGRESO";
                ViewBag.egreso = EgresoDAO.getInstancia().getEgresoById(id_egreso);
                ViewBag.items = ItemDAO.getInstancia().getItemsDeEgreso(id_egreso);

                return View("Mostrar");
            }

        }

        [HttpPost]
        public ActionResult MostrarEgresos()
        {

            ViewBag.egresos = EgresoDAO.getInstancia().getAllEgreso();
            if (ViewBag.egresos.Count > 0)
            {
                ViewBag.mostrar = "EGRESOS";
                return View("Mostrar");
            }

            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "No hay egresos actualmente";
                return View("Mostrar");
            }

        }

        #endregion

        #region Ingresos

        [HttpPost]
        public ActionResult CargarAsociar()
        {
            return View("Ingreso");
        }

        [HttpPost]
        public ActionResult BuscarIngreso(int id_ingreso = -1)
        {
            if (id_ingreso == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un ingreso";

                return View("Mostrar");
            }
            else
            {
                ViewBag.mostrar = "INGRESO";
                ViewBag.ingreso = IngresoDAO.getInstancia().getIngresoById(id_ingreso);
                
                return View("Mostrar");
            }
        }

        [HttpPost]
        public ActionResult MostrarIngresos()
        {
            ViewBag.ingresos = IngresoDAO.getInstancia().getAllIngreso();

            if (ViewBag.ingresos.Count > 0)
            {
                ViewBag.mostrar = "INGRESOS";
                return View("Mostrar");
            }

            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "No hay ingresos actualmente";
                return View("Mostrar");
            }

        }

        #endregion

        #region Proyectos

        [HttpPost]
        public ActionResult CargarVincular()
        {
            return View("Proyecto");
        }

        [HttpPost]
        public ActionResult BuscarProyecto(int id_proyecto = -1)
        {
            if (id_proyecto == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe ingresar un proyecto";

                return View("Mostrar");
            }
            else
            {
                ViewBag.mostrar = "PROYECTO";
                ViewBag.proyecto = ProyectoDAO.getInstancia().getProyectoById(id_proyecto);

                return View("Mostrar");
            }

        }

        [HttpPost]
        public ActionResult MostrarProyectos()
        {

            ViewBag.proyectos = ProyectoDAO.getInstancia().getAllProyectos();
            if (ViewBag.proyectos.Count > 0)
            {
                ViewBag.mostrar = "PROYECTOS";
                return View("Mostrar");
            }

            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "No hay proyectos actualmente";
                return View("Mostrar");
            }

        }

        #endregion

        #region Proveedores

        [HttpPost]
        public ActionResult RegistrarProveedores()
        {
            return View("Proveedores");
        }

        [HttpPost]
        public ActionResult MostrarProveedores()
        {

            ViewBag.proveedores = ProveedorDAO.getInstancia().getAllProveedores();
            if (ViewBag.proveedores.Count > 0)
            {
                ViewBag.mostrar = "PROVEEDORES";
                return View("Mostrar");
            }

            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "No hay proveedores actualmente";
                return View("Mostrar");
            }

        }

        #endregion

        #region Criterios y Categorias

        [HttpPost]
        public ActionResult CargarCriteriosCategorias()
        {
            return View("CriteriosCategorias");
        }
        
        [HttpPost]
        public ActionResult MostrarCriterios()
        {

            ViewBag.criterios = CriterioCategoriaDAO.getInstancia().getAllCriterios();
            if (ViewBag.criterios.Count > 0)
            {
                ViewBag.mostrar = "CRITERIOS";
                return View("Mostrar");
            }

            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "No hay criterios actualmente";
                return View("Mostrar");
            }

        }

        [HttpPost]
        public ActionResult MostrarCategorias()
        {

            ViewBag.categorias = CriterioCategoriaDAO.getInstancia().getAllCategorias();
            if (ViewBag.categorias.Count > 0)
            {
                ViewBag.mostrar = "CATEGORIAS";
                return View("Mostrar");
            }

            else
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "No hay categorias actualmente";
                return View("Mostrar");
            }

        }
        
        #endregion

        #region Usuarios
        public ActionResult verBitacora()
        {
            var usuario = UsuarioDAO.getInstancia().getUsuarioByUserName(Session["UserName"].ToString());

            if (usuario.esAdministrador) 
            {
                ViewBag.mostrar = "BITACORA";
                ViewBag.bitacora = TP_Anual.MongoDB.getInstancia().mostrarBitacora();
                return View("Mostrar");
            }
            else 
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Solo los usuarios administradores pueden ver la bitacora";
                return View("Mostrar");
            } 
        }

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

            if (obj == null)
            {
                ViewBag.msg = "No existe el usuario";
                return View("Login");
            }
            else if (obj.contrasenia != contrasenia)
            {
                ViewBag.msg = "Contraseña incorrecta";
                return View("Login");
            }

            Session["UserID"] = obj.id.ToString();
            Session["UserName"] = obj.nombre;
            return RedirectToAction("UserDashBoard");
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
        public ActionResult RegisterTry(string username, string password, string esAdmin)
        {
            if (UsuarioDAO.getInstancia().getUsuarioByUserName(username) != null)
            {
                ViewBag.msg = "Ya existe un usuario con ese nombre";
                return View("Register");
            }
            else
            {
                UsuarioDAO.getInstancia().Add(new Usuario(username, password, esAdmin == "grupo5"));
                return View("Login");
            }
        }

        #endregion

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
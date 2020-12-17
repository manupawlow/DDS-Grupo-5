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
        public ActionResult BuscarEgreso(int id_egreso = -1)
        {
            if(id_egreso == -1)
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
        public ActionResult CargarEgreso(string descripcion = "", string revisor = "", int cantPresup = -1, FormCollection inputs = null)
        {
            if (descripcion == "" || revisor == "" || cantPresup == -1)
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else
            {
                var usuario = UsuarioDAO.getInstancia().getUsuarioByUserName(revisor);

                if(usuario == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "No existe el usuario ingresado";

                    return View("Mostrar");
                }
                else
                {
                    if (inputs["nuevoItem"] != null || inputs["cantidad"] != null)
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
                    ViewBag.error = "Solo el usuario revisor del egreso puede ver la bandeja de mensajes";

                    return View("Mostrar");
                }
                else
                {
                    if(egreso.bandejaDeMensajes.mensajes == null)
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

            

        [HttpPost]
        public ActionResult ValidarEgreso(int id_egreso = -1)
        {
            if(id_egreso == -1)
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
        #endregion

        #region Ingresos

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
                Ingreso nuevo = new Ingreso(descripcion, total);
                IngresoDAO.getInstancia().Add(nuevo);

                return View("Index");
            }
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
        public ActionResult AgregarPresupuesto(int id_egreso = -1, string CUIT ="", FormCollection inputs = null)
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

                if(egreso == null || proveedor == null ) 
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

        #endregion

        #region Proyectos

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


        [HttpPost]
        public ActionResult CargarProyecto(int monto =-1, int cant_presupuestos =-1, string usuario = "")
        {
            if (monto == -1 || cant_presupuestos == -1 || usuario == "")
            {
                ViewBag.mostrar = "ERROR";
                ViewBag.error = "Debe completar todos los campos";

                return View("Mostrar");
            }
            else 
            {
                if (UsuarioDAO.getInstancia().getUsuarioByUserName(usuario) == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "No existe el usuario ingresado";

                    return View("Mostrar");
                }
                else
                {
                    ProyectoDAO.getInstancia().cargarProyecto(cant_presupuestos, monto, usuario);

                    return View("Index");

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

                if(ingreso == null || proyecto == null)
                {
                    ViewBag.mostrar = "ERROR";
                    ViewBag.error = "Los datos ingresados no son validos";

                    return View("Mostrar");
                }
                else
                {
                    ProyectoDAO.getInstancia().vincularIngresoConProyecto(id_proyecto, id_ingreso);

                    return View("Index");

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

                    return View("Index");
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

                    return View("Index");
                }
            }
        }

        #endregion

        #region Proveedores
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
                    var nuevo = new CriterioPorItem();
                    nuevo.item = item;
                    nuevo.criterio = cri;
                    nuevo.categoria_item = cat;

                    CriterioCategoriaDAO.getInstancia().AddCriterioPorItem(nuevo);

                    return View("Index");

                }
            }



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

                return View("Index");

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

                    return View("Index");
                }
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
using PruebaWeb.DAOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Http;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using PruebaCodigo;

namespace PruebaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BuscarUsuarioSinAjax(string usuario)
        {

            ViewBag.usuario = UsuarioDAO.getInstancia().usuarios.Find(u => u.nombre == usuario);

            return View("Index");

        }

        [HttpPost]
        public ActionResult CrearUsuario(int usuarioId, string nombre, string contrasenia)
        {
            Usuario nuevo = new Usuario(usuarioId, nombre, contrasenia);
            UsuarioDAO.getInstancia().add(nuevo);

            ViewBag.usuario = UsuarioDAO.getInstancia().getUsuarioById(usuarioId);

            return View("Index");

        }

        [HttpPost]
        public ActionResult Tweetear(int usuarioId, string texto)
        {
            Tweet nuevo = new Tweet(texto);
            var usuario = UsuarioDAO.getInstancia().getUsuarioById(usuarioId);
            usuario.twits.Add(nuevo);

            //ViewBag.usuario = UsuarioDAO.getInstancia().getUsuarioById(usuarioId);

            return View("Index");

        }

        //LOGIN
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginTry(string usuario, string contrasenia)
        {
            var obj = UsuarioDAO.getInstancia().usuarios.Find(a => a.nombre == usuario);
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
            {
                return View("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterTry(string username, string password)
        {
            var rnd = new Random();
            int usuarioId = rnd.Next(4, 200);
            Usuario nuevo = new Usuario(usuarioId, username, password);
            
            UsuarioDAO.getInstancia().add(nuevo);

            return View("Login");
        }

    }
}
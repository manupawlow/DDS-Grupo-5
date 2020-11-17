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
using Microsoft.Ajax.Utilities;

namespace PruebaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public JsonResult Tweetear([FromBody] FormCollection jsonTweets)
        {
            var usuario = UsuarioDAO.getInstancia().getUsuarioById(3);
            //var t = Request.Form["nuevoTweet1"];
            var t = jsonTweets["nuevoTweet1"];
            usuario.tweets.Add(new Tweet(t));

            //foreach (JsonTweet t in jsonTweets)
            //{
            //    usuario.tweets.Add(new Tweet(t.texto));
            //}

            return Json(JsonConvert.SerializeObject(usuario));

        }*/
        [HttpPost]
        public ActionResult Tweetear(string tweeteador, FormCollection tweets)
        {

            var usuario = UsuarioDAO.getInstancia().usuarios.Find(u => u.nombre == tweeteador);

            var a = tweets["nuevoTweet"];
            var b = a.Split(',');

            foreach (var t in b)
            {
                usuario.tweets.Add(new Tweet(t));
            }

            return View("Index");
        }


        [HttpPost]
        public JsonResult BuscarUsuario([FromBody] JsonUsuario jsonUsuario)
        {

            var usuario = UsuarioDAO.getInstancia().usuarios.Find(u => u.nombre == jsonUsuario.nombre);

            return Json(JsonConvert.SerializeObject(usuario));

        }

        public class JsonUsuario
        {
            public int id { get; set; } 
            public string nombre { get; set; }
            public string contrasenia { get; set; }
        }

        public class JsonTweet
        {
            public string texto { get; set; }
        }

        [HttpPost]
        public JsonResult CrearUsuario([FromBody] JsonUsuario jsonUsuario)
        {
            var rnd = new Random();
            int usuarioId = rnd.Next(4, 200);
            Usuario nuevo = new Usuario(usuarioId, jsonUsuario.nombre, jsonUsuario.contrasenia);
            UsuarioDAO.getInstancia().add(nuevo);

            return Json(JsonConvert.SerializeObject(nuevo));
        }



        //LOGIN----------------------------------------------
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


        [HttpPost]
        public ActionResult usuarios()
        {
            ViewBag.usuarios = UsuarioDAO.getInstancia().usuarios;
            return View("Index");
        }

    }
}
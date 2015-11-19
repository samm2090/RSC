using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Core.Entities;
using Dominio.MainModule;

namespace Red_Social_Citas.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {

            UsuarioManager usuManager = new UsuarioManager();

            usuManager.RegistrarUsuario(usuario);
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            return RedirectToAction("Perfil", "Perfil");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Core.Entities;
using Dominio.MainModule;

namespace Red_Social_Citas.Controllers
{
    public class UsuarioController : Controller
    {

        //  [HttpPost]
        public ActionResult Registrar()//Usuario usuario
        {
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                // Session["usuario"] = usuario;
                ViewBag.tallas = new SelectList(usuarioManager.ListarTallas(), "cod_talla", "desc_talla");
                ViewBag.rasgos = usuarioManager.ListarRasgos();

            }
            return View();
        }

        [HttpPost]
        public ActionResult Registrar2()//Usuario usuario
        {
            //if (ModelState.IsValid)
            //{
            //    UsuarioManager usuarioManager = new UsuarioManager();

            //    // Session[S"usuario"] = usuario;
            // //   ViewBag.tallas = new SelectList(usuarioManager.ListarTallas(), "cod_talla", "desc_talla");
            //  //  ViewBag.rasgos = usuarioManager.ListarRasgos();

            //}
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            return View();
        }
    }
}

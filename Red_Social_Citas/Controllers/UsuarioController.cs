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

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {

            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["usuario"] = usuario;
            }

            ViewBag.tallas = new SelectList(usuarioManager.ListarTallas(), "cod_talla", "desc_talla");
            ViewBag.rasgos = usuarioManager.ListarRasgos();
            return View();

        }

        [HttpPost]
        public ActionResult Registrar2(InformacionUsuario infoUsu)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["infoUsu"] = infoUsu;
            }

            ViewBag.contexturas = new SelectList(usuarioManager.listarContexturas(), "cod_contex", "desc_contex");
            ViewBag.estCivs = new SelectList(usuarioManager.listarEstadosCiviles(), "cod_estCiv", "desc_estCiv");

            return View();
        }

        [HttpPost]
        public ActionResult Registrar3(InformacionUsuario infoUsu)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["infoUsu"] = infoUsu;
            }

            ViewBag.cualidades = usuarioManager.listarCualidades();
            return View();
        }

        [HttpPost]
        public ActionResult Registrar4(InformacionUsuario infoUsu)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["infoUsu"] = infoUsu;
            }

            ViewBag.actividades = usuarioManager.listarActividades();
            ViewBag.ingresos = new SelectList(usuarioManager.listarIngresos(), "cod_ing", "desc_ing");

            return View();  
        }

        [HttpPost]
        public ActionResult Registrar5(Intereses intereses)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["intereses"] = intereses;
            }

            ViewBag.tallaRangos = new SelectList(usuarioManager.listarTallaRangos(), "cod_talla_ran", "desc_talla_ran");
            ViewBag.rasgos = usuarioManager.ListarRasgos();

            return View();
        }

        [HttpPost]
        public ActionResult Registrar6(Intereses intereses)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["intereses"] = intereses;
            }

            ViewBag.contexturas = new SelectList(usuarioManager.listarContexturas(), "cod_contex", "desc_contex");

            return View();
        }

        [HttpPost]
        public ActionResult Registrar7(Intereses intereses)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["intereses"] = intereses;
            }

            ViewBag.cualidades = usuarioManager.listarCualidades();

            return View();
        }

        [HttpPost]
        public ActionResult Registrar8(Intereses intereses)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            if (ModelState.IsValid)
            {
                Session["intereses"] = intereses;
            }

            //ViewBag.cualidades = usuarioManager.listarCualidades();

            return View();
        }



        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            return View();
        }
    }
}

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
            if (usuario.nom_usu == null || usuario.apePat_usu == null || usuario.apeMat_usu==null  ||
               usuario.sexo_usu== null|| usuario.fecNac_usu== null  || usuario.email_usu== null )
            {
                return RedirectToAction("Index", "Index");
            }
            else
            {
                UsuarioManager m = new UsuarioManager();

                Session["usuario"] = usuario;
                ViewBag.tallas = new SelectList(m.ListarTallas(), "desc_talla", "cod_talla");
                
                return View();
            }

        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            return View(); 
        }
    }
}

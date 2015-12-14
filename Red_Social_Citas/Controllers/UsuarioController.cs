using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Core.Entities;
using Dominio.MainModule;
using System.Configuration;

namespace Red_Social_Citas.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();
                usuarioManager.RegistrarUsuario(usuario);
                Session["usuario"] = usuarioManager.BuscarUsuario(usuario);
                ViewBag.tallas = new SelectList(usuarioManager.ListarTallas(), "cod_talla", "desc_talla");
                ViewBag.rasgos = usuarioManager.ListarRasgos();
            }
           
            return View();
        }

        [HttpPost]
        public ActionResult Registrar2(int cod_talla, int cod_rasgo)
        {
          
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();
                InformacionUsuario infoUsu = new InformacionUsuario();
                Usuario usuario = (Usuario) Session["usuario"];
                infoUsu.cod_usu = usuario.cod_usu;
                infoUsu.cod_talla = cod_talla;
                infoUsu.cod_rasgo = cod_rasgo;
                Session["infoUsu"] = infoUsu;

                ViewBag.contexturas = new SelectList(usuarioManager.listarContexturas(), "cod_contex", "desc_contex");
                ViewBag.estCivs = new SelectList(usuarioManager.listarEstadosCiviles(), "cod_estCiv", "desc_estCiv");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Registrar3(int cod_contex, int cod_estCiv)
        {
          
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                InformacionUsuario infoUsu = (InformacionUsuario)Session["infoUsu"];
                infoUsu.cod_contex = cod_contex;
                infoUsu.cod_estCiv = cod_estCiv;
                Session["infoUsu"] = infoUsu;

                ViewBag.cualidades = usuarioManager.listarCualidades();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Registrar4(int hijos_usu)
        {
           
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager(); 

                InformacionUsuario infoUsu = (InformacionUsuario)Session["infoUsu"];
                infoUsu.hijos_usu= hijos_usu;
                Session["infoUsu"] = infoUsu;

                String cod_cua = Request["cod_cua"];
                String[] str_cc = cod_cua.Split(',');
                List<int> int_cc = new List<int>();

                foreach (String i in str_cc)
                {
                    int_cc.Add(Int32.Parse(i));
                }

                List<CualidadesUsuario> cuaUsus = new List<CualidadesUsuario>();
                Usuario usuario = (Usuario)Session["usuario"];

                foreach (int cua in int_cc)
                {
                    CualidadesUsuario cuaUsu = new CualidadesUsuario();
                    cuaUsu.cod_usu = usuario.cod_usu;
                    cuaUsu.cod_cua = cua;

                    cuaUsus.Add(cuaUsu);
                }

                usuarioManager.RegistrarCuaUsu(cuaUsus);
                ViewBag.actividades = usuarioManager.listarActividades();
                ViewBag.ingresos = new SelectList(usuarioManager.listarIngresos(), "cod_ing", "desc_ing");
            }
            return View();  
        }

        [HttpPost]
        public ActionResult Registrar5(int cod_act, int cod_ing)
        {
            
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                InformacionUsuario infoUsu = (InformacionUsuario)Session["infoUsu"];
                infoUsu.cod_act = cod_act;
                infoUsu.cod_ing = cod_ing;
                Session["infoUsu"] = infoUsu;

                usuarioManager.RegistrarInfoUsu(infoUsu);

                ViewBag.tallaRangos = new SelectList(usuarioManager.listarTallaRangos(), "cod_talla_ran", "desc_talla_ran");
                ViewBag.rasgos = usuarioManager.ListarRasgos();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Registrar6(int cod_talla_ran, int cod_rasgo)
        {
           
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                Usuario usuario =(Usuario) Session["usuario"];

                Intereses intereses = new Intereses();
                intereses.cod_usu = usuario.cod_usu;
                intereses.cod_talla_ran=cod_talla_ran;
                intereses.cod_rasgo=cod_rasgo;
                Session["intereses"] = intereses;

                ViewBag.contexturas = new SelectList(usuarioManager.listarContexturas(), "cod_contex", "desc_contex");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Registrar7(int cod_contex, String hijos_interes)
        {
           
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                Intereses intereses = (Intereses)Session["intereses"];
                intereses.cod_contex = cod_contex;
                intereses.hijos_interes = hijos_interes;

                Session["intereses"] = intereses;

                ViewBag.cualidades = usuarioManager.listarCualidades();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Registrar8(String ing_interes)
        {
          
            if (ModelState.IsValid)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                Intereses intereses = (Intereses)Session["intereses"];
                intereses.ing_interes = ing_interes;
                Session["intereses"] = intereses;
                usuarioManager.RegistrarInt(intereses);

                String cod_cua = Request["cod_cua"];
                String[] str_cc = cod_cua.Split(',');
                List<int> int_cc = new List<int>();

                foreach (String i in str_cc)
                {
                    int_cc.Add(Int32.Parse(i));
                }


                Usuario usuario = (Usuario) Session["usuario"];
                List<CualidadesInteres> cuaInts = new List<CualidadesInteres>();
                foreach (int cua in int_cc)
                {
                    CualidadesInteres cuaInt = new CualidadesInteres();
                    cuaInt.cod_usu = usuario.cod_usu;
                    cuaInt.cod_cua = cua;

                    cuaInts.Add(cuaInt);
                }

                usuarioManager.RegistrarCuaInt(cuaInts);

            }

            return View();
        }


        [HttpPost]
        public ActionResult Registrar9()
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            string ruta1 = Server.MapPath(ConfigurationManager.AppSettings["Fotos"]) +
                                    System.IO.Path.GetFileName(Request.Files["foto1"].FileName);
            //string ruta2 = Server.MapPath(ConfigurationManager.AppSettings["Fotos"]) +
            //                        System.IO.Path.GetFileName(Request.Files["foto2"].FileName);
            //string ruta3 = Server.MapPath(ConfigurationManager.AppSettings["Fotos"]) +
            //                        System.IO.Path.GetFileName(Request.Files["foto3"].FileName);

            Request.Files["foto1"].SaveAs(ruta1);
            
            Foto foto = new Foto();

            Usuario usuario = (Usuario)Session["usuario"];
            foto.cod_usu = usuario.cod_usu;
            foto.ruta = Request.Files["foto1"].FileName;
            usuarioManager.InsertarFoto(foto);
            
            return RedirectToAction("Perfil");
        }

        public ActionResult Perfil()
        {

            UsuarioManager usuarioManager = new UsuarioManager();

            Usuario usuario = (Usuario) Session["usuario"];
            usuarioManager.actualizarCompatibilidad(usuario);


            Foto foto = usuarioManager.buscarFoto(usuario);
            ViewBag.ruta = foto.ruta;
            List<Usuario> usuarios = usuarioManager.listarUsuariosFiltro(usuario);

            ViewBag.usuarios = usuarios;

            return View();
        }   


        [HttpPost]
        public ActionResult Login(String email, String contrasena)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            Usuario usu = new Usuario();
            usu.email_usu = email;
            usu.contr_usu = contrasena;
            
            Usuario usuario = usuarioManager.BuscarUsuario(usu);

            if(usuario !=null){

                Session["usuario"] = usuario;
                Foto foto = usuarioManager.buscarFoto(usuario);

                ViewBag.ruta = foto.ruta;
                               
                return RedirectToAction("Perfil");
            }

            return RedirectToAction("Index","Index");
        }

        [HttpPost]
        public ActionResult OpcionesPareja()
        {

            if (Request.Form["mensaje"] != null)
            {
                return RedirectToAction("Mensajes",new {cod_usu2 = Request["cod_usu2"]});
            }
            else
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                Usuario usuario = (Usuario)Session["usuario"];
                usuarioManager.RegistrarFavorito(usuario,Request["cod_usu2"]);

                return RedirectToAction("Perfil");
            }
            

        }

        public ActionResult Mensajes(string cod_usu2)
        {


            return View();
        }


        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Index");
        }
    }
}

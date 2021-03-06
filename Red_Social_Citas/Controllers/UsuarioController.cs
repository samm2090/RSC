﻿using System;
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

            usuario.foto = foto.ruta;

            Session["usuario"] = usuario;

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
                               
                return RedirectToAction("Perfil");
            }
            
            return RedirectToAction("Index","Index",new {error = "Credenciales invalidas"});
        }

        [HttpPost]
        public ActionResult OpcionesPareja()
        {

            if (Request.Form["mensaje"] != null)
            {
                return RedirectToAction("Mensajes",new {cod_usu2 = Request["cod_usu2"]});
            }
            else if(Request.Form["favorito"]!=null)
            {
                UsuarioManager usuarioManager = new UsuarioManager();

                Usuario usuario = (Usuario)Session["usuario"];
                usuarioManager.RegistrarFavorito(usuario,Request["cod_usu2"]);
                String cod = Request["cod_usu2"];

                Usuario usuario2 = usuarioManager.BuscarUsuario(Int32.Parse(cod));
       
                Session["usuario2"] = usuario2;

                return RedirectToAction("Perfil");
            }
            else
            {
                return RedirectToAction("PerfilCompleto", new { cod_usu2 = Request["cod_usu2"] });

            }
            

        }


        public ActionResult PerfilCompleto(string cod_usu2)
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            Usuario usuario2 = usuarioManager.BuscarUsuario(Int32.Parse(cod_usu2));
            usuario2.foto = usuarioManager.buscarFoto(usuario2).ruta;

            Session["usuario2"] = usuario2;

            ViewBag.talla = usuarioManager.buscarTalla(usuario2);
            ViewBag.estCiv = usuarioManager.buscarEstCiv(usuario2);
            ViewBag.rasgo = usuarioManager.buscarRasgo(usuario2);
            ViewBag.contextura = usuarioManager.buscarContextura(usuario2);
            ViewBag.actividad = usuarioManager.buscarActividad(usuario2);

            ViewBag.cualidades = usuarioManager.buscarCualidades(usuario2);

            return View();

        }

        public ActionResult Mensajes(string cod_usu2)
        {
           
            UsuarioManager usuarioManager = new UsuarioManager();
            Usuario usuario2 = usuarioManager.BuscarUsuario(Int32.Parse(cod_usu2));
            usuario2.foto = usuarioManager.buscarFoto(usuario2).ruta;

            Session["usuario2"] = usuario2;

            Usuario usuario = (Usuario)Session["usuario"];

            ViewBag.foto1 = usuario.foto;
            ViewBag.foto2 = usuario2.foto;

            MensajeManager mensajeManager = new MensajeManager();
            Mensaje mensaje = new Mensaje();
            mensaje.cod_usu1 = usuario.cod_usu;
            usuario = (Usuario)Session["usuario2"];
            mensaje.cod_usu2 = usuario.cod_usu;
            List<Mensaje> mensajes = mensajeManager.listarMensajes(mensaje);
            ViewBag.mensajes = mensajes;

            return View();
        }

        [HttpPost]
        public ActionResult EnviarMensaje()
        {
            MensajeManager mensajeManager = new MensajeManager();

            Mensaje mensaje = new Mensaje();
            Usuario usuario = (Usuario)Session["usuario"];
            mensaje.cod_usu1 = usuario.cod_usu;
            usuario = (Usuario)Session["usuario2"];
            mensaje.cod_usu2 = usuario.cod_usu;
            mensaje.mensaje = Request.Form["mensaje"];

            mensajeManager.EnviarMensaje(mensaje);

            List<Mensaje> mensajes = mensajeManager.listarMensajes(mensaje);
            ViewBag.mensajes = mensajes;
            return View();
        }


        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Index");
        }

        [HttpPost]
        public ActionResult Actualizar()
        {
            if (Request.Form["perfil"] != null)
            {
                return RedirectToAction("MiPerfilCompleto");
            }
            else
            {
                
                string ruta1 = Server.MapPath(ConfigurationManager.AppSettings["Fotos"]) +
                               System.IO.Path.GetFileName(Request.Files["foto1"].FileName);


                if (!ruta1.Equals("C:\\Proyecto_DEW\\Red_Social_Citas\\Fotos\\"))
                {
                    Request.Files["foto1"].SaveAs(ruta1);

                    Foto foto = new Foto();

                    UsuarioManager usuarioManager = new UsuarioManager();

                    Usuario usuario = (Usuario)Session["usuario"];
                    foto.cod_usu = usuario.cod_usu;
                    foto.ruta = Request.Files["foto1"].FileName;
                    usuarioManager.ActualizarFoto(foto);

                    usuario.foto = foto.ruta;

                    Session["usuario"] = usuario;
                }
                return RedirectToAction("Perfil");
            }
        }

        public ActionResult MiPerfilCompleto()
        {
            UsuarioManager usuarioManager = new UsuarioManager();
            Usuario usuario = (Usuario)Session["usuario"];

            ViewBag.talla = usuarioManager.buscarTalla(usuario);
            ViewBag.estCiv = usuarioManager.buscarEstCiv(usuario);
            ViewBag.rasgo = usuarioManager.buscarRasgo(usuario);
            ViewBag.contextura = usuarioManager.buscarContextura(usuario);
            ViewBag.actividad = usuarioManager.buscarActividad(usuario);

            ViewBag.cualidades = usuarioManager.buscarCualidades(usuario);


            return View();
        }

        public ActionResult ActualizarDatos()
        {
            Usuario usuarioNuevo = new Usuario();
            Usuario usuario = (Usuario)Session["usuario"];
            usuarioNuevo.nom_usu = Request["nom_usu"];
            usuarioNuevo.apePat_usu = Request["apePat_usu"];
            usuarioNuevo.apeMat_usu = Request["apeMat_usu"];
            usuarioNuevo.cod_usu = usuario.cod_usu;
            

            UsuarioManager usuarioManager = new UsuarioManager();

            usuarioManager.actualizarDatos(usuarioNuevo);

            usuario = usuarioManager.BuscarUsuario(usuario);


            Foto foto = new Foto();
            
            usuario.foto = usuarioManager.buscarFoto(usuario).ruta;

            Session["usuario"] = usuario;

            return RedirectToAction("MiPerfilCompleto");

        }
    }
}

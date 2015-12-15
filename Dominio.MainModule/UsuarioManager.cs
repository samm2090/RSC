using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SQLServer;
using Dominio.Core.Entities;

namespace Dominio.MainModule
{
    public class UsuarioManager
    {
        Usuario_DAL usuarioDAL = new Usuario_DAL();
        InformacionUsuario_DAL infoUsuDAL = new InformacionUsuario_DAL();
        Intereses_DAL interesesDAL = new Intereses_DAL();
        CualidadesUsuario_DAL cuaUsuDAL = new CualidadesUsuario_DAL();
        CualidadesInteres_DAL cuaIntDAL = new CualidadesInteres_DAL();
        Talla_DAL tallaDAL = new Talla_DAL();
        Rasgo_DAL rasgoDAL = new Rasgo_DAL();
        Contextura_DAL contexturaDAL = new Contextura_DAL();
        EstadoCivil_DAL estCivDAL = new EstadoCivil_DAL();
        
        Foto_DAL fotoDAL = new Foto_DAL();

      
        public Usuario BuscarUsuario(Usuario usuario)
        {
            return usuarioDAL.BuscarUsuario(usuario);
        }

        public Usuario BuscarUsuario(int cod_usu2)
        {
            return usuarioDAL.BuscarUsuario(cod_usu2);
        }


        public String RegistrarUsuario(Usuario usuario)
        {
            return usuarioDAL.RegistrarUsuario(usuario);     
        }

        public String InsertarFoto(Foto foto)
        {
            return fotoDAL.InsertarFoto(foto);
        }

        public IEnumerable<Talla> ListarTallas()
        {
            return tallaDAL.ListarTallas();
        }

        public IEnumerable<Rasgo> ListarRasgos()
        {
            return rasgoDAL.ListarRasgos();
        }

        public IEnumerable<Contextura> listarContexturas()
        {
            return contexturaDAL.ListarContexturas();
        }

        public IEnumerable<EstadoCivil> listarEstadosCiviles()
        {
            return estCivDAL.ListarEstadosCiviles();
        }

        public IEnumerable<Cualidad> listarCualidades()
        {
            Cualidad_DAL cualidadDAL = new Cualidad_DAL();
            return cualidadDAL.ListarCualidades();
        }

        public IEnumerable<Actividad> listarActividades()
        {
            Actividad_DAL actividadDAL= new Actividad_DAL();
            return actividadDAL.ListarActividades();
        }

        public IEnumerable<Ingresos> listarIngresos()
        {
            Ingresos_DAL ingresosDAL = new Ingresos_DAL();
            return ingresosDAL.ListarIngresos();
        }

        public IEnumerable<TallaRango> listarTallaRangos()
        {
            TallaRango_DAL tallaRangoDAL = new TallaRango_DAL();
            return tallaRangoDAL.ListarTallasRangos();
        }


        public String RegistrarInfoUsu(InformacionUsuario infoUsu)
        {
            return infoUsuDAL.RegistrarInformacionUsuario(infoUsu);
        }

        public String  RegistrarCuaUsu(List<CualidadesUsuario> cuaUsu)
        {
            return cuaUsuDAL.IngresarCualidadesUsuarios(cuaUsu);
        }

        public String RegistrarCuaInt(List<CualidadesInteres> cuaInts)
        {
            return cuaIntDAL.IngresarCualidadInteres(cuaInts);
        }

        public String RegistrarInt(Intereses intereses)
        {
            return interesesDAL.RegistrarIntereses(intereses);
        }

        public Foto buscarFoto(Usuario usuario)
        {
            return fotoDAL.buscarFoto(usuario);
        }

        public List<Usuario> listarUsuariosFiltro(Usuario usuario)
        {
            return usuarioDAL.listarUsuariosFiltro(usuario);
        }

        public void actualizarCompatibilidad(Usuario usuario)
        {
            usuarioDAL.actualizarCompatibilidad(usuario);
        }

        public void RegistrarFavorito(Usuario usuario,string cod_usu2)
        {
            usuarioDAL.RegistrarFavorito(usuario, Int32.Parse(cod_usu2));
        }

        
        public String buscarTalla(Usuario usuario2)
        {
            return tallaDAL.buscarTalla(usuario2);
        }

        public String buscarEstCiv(Usuario usuario2)
        {
            return estCivDAL.buscarEstCiv(usuario2);
        }

        public String buscarRasgo(Usuario usuario2)
        {
            return rasgoDAL.buscarRasgo(usuario2);
        }

        public String buscarContextura(Usuario usuario2)
        {
            return contexturaDAL.buscarContextura(usuario2);
        }

        public String buscarActividad(Usuario usuario2)
        {
            Actividad_DAL actDAL = new Actividad_DAL();
            return actDAL.buscarActividad(usuario2);
        }

        public List<String> buscarCualidades(Usuario usuario2)
        {
            Cualidad_DAL cualidadDAL = new Cualidad_DAL();
            return cualidadDAL.buscarCualidades(usuario2);
        }

        public void ActualizarFoto(Foto foto)
        {
            fotoDAL.actualizarFoto(foto);
        }

        public void actualizarDatos(Usuario usuario)
        {
            usuarioDAL.ActualizarUsuario(usuario);
        }
    }
}

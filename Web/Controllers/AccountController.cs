using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BI;
using SL.Excepciones;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        INEGAbmCliente interfazAbmCliente = new NEGAbmCliente();
        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();

        [HttpGet]
        public ActionResult altaCV()
        {
            this.inicializar_idioma();
            return View();
        }

        [HttpGet]
        public ActionResult altaCliente()
        {
            this.inicializar_idioma();

            //try
            //{
            //    var listadoOpcionesDePago = interfazAbmCliente.obtenerOpcionesDePago();

            //    ViewBag.opcionDePago = new SelectList(listadoOpcionesDePago, "idOpcionDePago", "nombre");


            //}
            //catch (Exception ex)
            //{
            //    WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
            //    interfazServiceLayer.registrarEvento(oWExcepcion);
            //}

            return View();
        }

        //[HttpGet]
        //public ActionResult altaEmpleado()
        //{
        //    this.inicializar_idioma();

        //    try
        //    {
        //        var listadoPuestos = interfazAbmCliente.obtenerPuestos();
        //        ViewBag.puesto = new SelectList(listadoPuestos, "idGrupo", "codigoGrupo");

        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    return View();
        //}

        [HttpGet]
        public ActionResult login()
        {
            this.inicializar_idioma();
            Session["usuario"] = "Invitado";

            return View();
        }

        [HttpGet]
        public ActionResult IngresaCV()
        {
            this.inicializar_idioma();
            return View();
        }

        [HttpGet]
        public ActionResult logout(Web.Models.LoginModel oLoginModel, string pUsuario)
        {
            foreach (ClsUsuario _usuario in Web.Models.ListadosGlobales.listadoUsuariosLogueados)
            {
                if (_usuario.usr == Session["usuario"].ToString())
                {
                    Web.Models.ListadosGlobales.listadoUsuariosLogueados.Remove(_usuario);
                    break;
                }
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Session.Clear();
            Session.Abandon();

            Session["usuario"] = "Invitado";
            this.inicializar_idioma();

            return View();
        }
        
  
        //[HttpPost]
        //public ActionResult altaCliente(Web.Models.ClienteUsuarioModel oClienteUsuario)
        //{

        //    try
        //    {
        //         bool bandera = true;

        //         if (oClienteUsuario.usuario != null)
        //        {
        //            bool resultado = interfazAbmCliente.verificarExistenciaUsuario(oClienteUsuario.usuario);
        //            if (!resultado)
        //            {
        //                bandera = false;
        //            }
        //        }
        //        else
        //        {
        //            bandera = false;
        //        }

        //         if (oClienteUsuario.password == null)
        //        {
        //            bandera = false;
        //        }
        //         else if (oClienteUsuario.password != oClienteUsuario.ConfirmPassword)
        //        {
        //            bandera = false;
        //        }


        //         if (oClienteUsuario.nombre == null)
        //        {
        //            bandera = false;
        //        }

        //         if (oClienteUsuario.telefono == null)
        //         {
        //             bandera = false;
        //         }

        //         if (oClienteUsuario.direccion == null)
        //         {
        //             bandera = false;
        //         }

        //         if (oClienteUsuario.email == null)
        //         {
        //             bandera = false;
        //         }


        //        if (bandera == true)
        //        {
        //            Cliente oCliente = new Cliente();
        //            oCliente.nombre = oClienteUsuario.nombre;
        //            oCliente.email = oClienteUsuario.email;
        //            oCliente.direccion = oClienteUsuario.direccion;
        //            oCliente.telefono = oClienteUsuario.telefono;

                  

        //            User oUsuario = new User();
        //            oUsuario.usuario = oClienteUsuario.usuario;
        //            oUsuario.password = oClienteUsuario.password;
        //            oUsuario.ConfirmPassword = oClienteUsuario.ConfirmPassword;


        //            interfazAbmCliente.altaCliente(oCliente, oUsuario);

        //            //Cargo el dropdownlist de opciones de pago nuevamente
        //            //var listadoOpcionesDePago = interfazAbmCliente.obtenerOpcionesDePago();
        //            //ViewBag.opcionDePago = new SelectList(listadoOpcionesDePago, "idOpcionDePago", "nombre");

        //            ViewBag.mostrarMensaje = "OK";
        //            ViewBag.mensaje = "Cliente generado correctamente";

        //            return RedirectToAction("Index", "Home", new { pMostrarMensaje = ViewBag.mostrarMensaje, pMensaje = ViewBag.mensaje });
        //        }
        //        else
        //        {
        //            //Cargo el dropdownlist de opciones de pago nuevamente
        //            //var listadoOpcionesDePago = interfazAbmCliente.obtenerOpcionesDePago();
        //            //ViewBag.opcionDePago = new SelectList(listadoOpcionesDePago, "idOpcionDePago", "nombre");

        //            ViewBag.mostrarMensaje = "ERROR";
        //            ViewBag.mensaje = "Debe completar correctamente todos los datos.";
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);

        //        ViewBag.mostrarMensaje = "ERROR";
        //        ViewBag.mensaje = "Se produjo un error al generar el Cliente";
        //    }


        //    return View();
        //}

        //[HttpPost]
        //public ActionResult altaEmpleado(Web.Models.EmpleadoUsuarioModel oEmpleadoUsuarioModel, int puesto)
        //{

        //    try
        //    {
        //        bool bandera = true;

        //        if (oEmpleadoUsuarioModel.usuario != null)
        //        {
        //            bool resultado = interfazAbmCliente.verificarExistenciaUsuario(oEmpleadoUsuarioModel.usuario);
        //            if (!resultado)
        //            {
        //                bandera = false;
        //            }
        //        }
        //        else
        //        {
        //            bandera = false;
        //        }

        //        if (oEmpleadoUsuarioModel.password == null)
        //        {
        //            bandera = false;
        //        }
        //        else if (oEmpleadoUsuarioModel.password != oEmpleadoUsuarioModel.ConfirmPassword)
        //        {
        //            bandera = false;
        //        }


        //        if (oEmpleadoUsuarioModel.nombre == null)
        //        {
        //            bandera = false;
        //        }

        //        if (oEmpleadoUsuarioModel.legajo== 0)
        //        {
        //            bandera = false;
        //        }

        //        if (oEmpleadoUsuarioModel.fechaNac == null)
        //        {
        //            bandera = false;
        //        }
                
        //        if (bandera == true)
        //        {
        //            Empleado oEmpleado = new Empleado();
        //            oEmpleado.nombre = oEmpleadoUsuarioModel.nombre;
        //            oEmpleado.legajo = oEmpleadoUsuarioModel.legajo;
        //            oEmpleado.fechaNac = oEmpleadoUsuarioModel.fechaNac;
        //            oEmpleado.fechaIngreso = DateTime.Now;

        //            Grupo oGrupo = new Grupo();
        //            oGrupo.idGrupo = puesto;
        //            oEmpleado.puesto = oGrupo;

        //            User oUsuario = new User();
        //            oUsuario.usuario = oEmpleadoUsuarioModel.usuario;
        //            oUsuario.password = oEmpleadoUsuarioModel.password;
        //            oUsuario.ConfirmPassword = oEmpleadoUsuarioModel.ConfirmPassword;

        //            interfazAbmCliente.altaEmpleado(oEmpleado, oUsuario);

        //            //Cargo nuevamente el dropsownlist()
        //            var listadoPuestos = interfazAbmCliente.obtenerPuestos();
        //            ViewBag.puesto = new SelectList(listadoPuestos, "idGrupo", "codigoGrupo");

        //            ViewBag.mostrarMensaje = "OK";
        //            ViewBag.mensaje = "Empleado generado correctamente";
        //        }
        //        else
        //        {
        //            //Cargo nuevamente el dropsownlist()
        //            var listadoPuestos = interfazAbmCliente.obtenerPuestos();
        //            ViewBag.puesto = new SelectList(listadoPuestos, "idGrupo", "codigoGrupo");

        //            ViewBag.mostrarMensaje = "ERROR";
        //            ViewBag.mensaje = "debe completar correctamente todos los datos.";
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);

        //        ViewBag.mostrarMensaje = "ERROR";
        //        ViewBag.mensaje = "Se produjo un error al generar el Empleado";
        //    }

        //    return View();
        //}


        [HttpPost]
        public ActionResult login(Web.Models.LoginModel oLoginModel)
        {

            Boolean resultado = false;
            try
            {
                resultado = interfazAbmCliente.validarUsuario(oLoginModel.usr, oLoginModel.password);
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }


            if (resultado == true)
            {
                //Validación correcta

                ClsUsuario oUsuario = new ClsUsuario();
                oUsuario.usr = oLoginModel.usr;
                oUsuario.password = oLoginModel.password;
                Web.Models.ListadosGlobales.listadoUsuariosLogueados.Add(oUsuario);
                //return RedirectToAction("Account", "altaCV", new { pUsuario = oLoginModel.usr.ToString() });
                return RedirectToAction("Index", "Home", new { pUsuario = oLoginModel.usr.ToString() });

            }
            else
            {

                //Validación incorrecta
                ViewBag.mostrarMensaje = "ERROR";
                ViewBag.mensaje = "Usuario y/o contraseña incorrecta, por favor ingreselos nuevamente";


                return View();
            }
        }

        [HttpPost]
        public ActionResult verificarExistenciaUsuario(string pUsuario)
        {

            bool resultado = false;

            try
            {

                resultado = interfazAbmCliente.verificarExistenciaUsuario(pUsuario);

            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }



            return RedirectToAction("altaCV", "Account");
        }


        // METODOS
        public void inicializar_idioma()
        {
            Session["altaCliente"] = Web.Code52.i18n.Language.altaCliente;
            Session["Campo"] = Web.Code52.i18n.Language.Campo;
            Session["Valor"] = Web.Code52.i18n.Language.Valor;
            Session["User"] = Web.Code52.i18n.Language.User;
            Session["Contrasena"] = Web.Code52.i18n.Language.Contrasena;
            Session["ConfirmarContrasena"] = Web.Code52.i18n.Language.ConfirmarContrasena;
            Session["Nombre"] = Web.Code52.i18n.Language.Nombre;
            Session["email"] = Web.Code52.i18n.Language.email;
            Session["direccion"] = Web.Code52.i18n.Language.direccion;
            Session["telefono"] = Web.Code52.i18n.Language.telefono;
            Session["Guardar"] = Web.Code52.i18n.Language.Guardar;
            Session["Cancelar"] = Web.Code52.i18n.Language.Cancelar;
            Session["Login"] = Web.Code52.i18n.Language.Login;
            Session["Ingresar"] = Web.Code52.i18n.Language.Ingresar;
            Session["IniciarSesion"] = Web.Code52.i18n.Language.IniciarSesion;
            Session["AltaCV"] = Web.Code52.i18n.Language.AltaCV;
            Session["efectivo"] = Web.Code52.i18n.Language.efectivo;
            Session["transferencia"] = Web.Code52.i18n.Language.transferencia;
            Session["legajo"] = Web.Code52.i18n.Language.legajo;
            Session["fechaNacimiento"] = Web.Code52.i18n.Language.fechaNacimiento;
            Session["puesto"] = Web.Code52.i18n.Language.puesto;
                
        }

    }
}

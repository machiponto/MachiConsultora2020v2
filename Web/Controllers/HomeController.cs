using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BI;
using BLL;
using SL.Excepciones;
using SL.Bitacora;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        INEGGestionServicio intNegGestionServicio = new NEGGestionServicio();

        INEGAbmCliente intNegAbmCliente = new NEGAbmCliente();
        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();

        ClsServicio oServicio = new ClsServicio();

        [HttpGet, OutputCache(NoStore = true, Duration = 1)]
        public ActionResult Index(string pUsuario, string pMostrarMensaje, string pMensaje)
        {

            this.inicializar_barra_superior();
            this.inicializar_barra_lateral();
            this.inicializar_contenido();

            List<ClsServicio> listadoServicios = new List<ClsServicio>();

            try
            {

             listadoServicios = intNegGestionServicio.obtenerServicios();

            if (Session["Perfil"] == null)
            {
                Session["Perfil"] = "";
            }

            if (Session["usuario"] == null || Session["usuario"].ToString().ToLower() == "invitado")
            {
                if (pUsuario != null)
                {
                    Session["usuario"] = pUsuario;
                    
                    //obtengo el perfil del usuario
                    string pPerfil = intNegAbmCliente.obtenerGruposPorUsuario(pUsuario);
                    Session["Perfil"] = pPerfil;
                }
                else
                {
                    Session["usuario"] = "Invitado";
                }
            }
            else if (Session["usuario"] != null)
            {

                if (pUsuario != null)
                {
                    Session["usuario"] = pUsuario;
                    
                    //obtengo el perfil del usuario
                    string pPerfil = intNegAbmCliente.obtenerGruposPorUsuario(pUsuario);
                    Session["Perfil"] = pPerfil;
                }
            }


            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            if (pMensaje != null && pMostrarMensaje != null)
            {

                @ViewBag.mostrarMensaje = pMostrarMensaje;
                @ViewBag.mensaje = pMensaje;

            }


                 return View(listadoServicios);
        }

        [HttpPost]
        public ActionResult Index(ClsServicio oServicio)
        {

            try
            {
                oServicio.listaServicios.Add(oServicio);

            }
            catch (Exception ex)
            {   
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View();
        }

        [HttpGet]
        public ActionResult DetalleCliente(string pUsuario)
        {

            Web.Models.DetalleCliente oDetalleCliente = new Web.Models.DetalleCliente();
            ClsCliente oCliente = new ClsCliente();

            try
            {

                oCliente = intNegAbmCliente.obtenerClientePorUsuario(pUsuario);
                if (oCliente.nombre != null)
                {

                    oDetalleCliente.idCliente = oCliente.idCliente;
                    oDetalleCliente.nombre = oCliente.nombre;
                    oDetalleCliente.email = oCliente.mail;
                    oDetalleCliente.direccion = oCliente.direccion;
                    oDetalleCliente.telefono = oCliente.telefono;

                    //if (oCliente.opcionDePago != null)
                    //{
                    //    oDetalleCliente.opcionDePago = oCliente.opcionDePago;
                    //}

                    //if (oCliente.oEmpleado != null)
                    //{
                    //    oDetalleCliente.oEmpleado = oCliente.oEmpleado;
                    //}

                    //    oDetalleCliente.listadoPedidos = intNegGestionPedido.obtenerPedidosDeCliente(oCliente.idCliente);
                }
                else
                {
                    ViewBag.mostrarMensaje = "ERROR";
                    ViewBag.mensaje = "Se produjo un error al obtener la información del cliente";

                    return View(oDetalleCliente);
                }


            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View(oDetalleCliente);
        }

        [HttpGet]
        public ActionResult editarCliente(int pIdCliente)
        {

            ClsCliente oCliente = new ClsCliente();

            try
            {

                oCliente = intNegAbmCliente.obtenerClientePorId(pIdCliente);
                //var listadoOpcionesDePago = intNegAbmCliente.obtenerOpcionesDePago();
                //ViewBag.opcionDePago = new SelectList(listadoOpcionesDePago, "idOpcionDePago", "nombre");

            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View(oCliente);
        }

        [HttpPost]
        public ActionResult editarCliente(ClsCliente oCliente, int opcionDePago, string pUsuario)
        {

            try
            {
                bool bandera = true;

                if (oCliente.nombre == null)
                {
                    bandera = false;
                }

                if (oCliente.telefono == null)
                {
                    bandera = false;
                }

                if (oCliente.direccion == null)
                {
                    bandera = false;
                }

                if (oCliente.mail == null)
                {
                    bandera = false;
                }


                if (bandera == true)
                {
                    //Verificar que el objeto este completo
                    //OpcionDePago oOpcionDePago = new OpcionDePago();
                    //oOpcionDePago.idOpcionDePago = opcionDePago;
                    //oCliente.opcionDePago = oOpcionDePago;

                    intNegAbmCliente.actualizarDatosCliente(oCliente);

                    //var listadoOpcionesDePago = intNegAbmCliente.obtenerOpcionesDePago();
                    //ViewBag.opcionDePago = new SelectList(listadoOpcionesDePago, "idOpcionDePago", "nombre");

                    ViewBag.mostrarMensaje = "OK";
                    ViewBag.mensaje = "Datos modificados correctamente";
                }
                else
                {
                    ViewBag.mostrarMensaje = "ERROR";
                    ViewBag.mensaje = "No deben existir campos vacíos, por favor verifique la información ingresada";

                    //var listadoOpcionesDePago = intNegAbmCliente.obtenerOpcionesDePago();
                    //ViewBag.opcionDePago = new SelectList(listadoOpcionesDePago, "idOpcionDePago", "nombre");

                    return View(oCliente);
                }


            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);

                ViewBag.mostrarMensaje = "ERROR";
                ViewBag.mensaje = "Se produjo un error al actualizar los datos";
            }

            return RedirectToAction("DetalleCliente", "Home", new { pUsuario = pUsuario });
        }

        //[HttpGet]
        //public ActionResult AndroidApp(string pUsuario)
        //{
        //    List<Pedido> listadoPedidos = new List<Pedido>();

        //    try
        //    {
        //        //   listadoPedidos = intNegGestionPedido.obtenerPedidosDeClientePorUsuario(pUsuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }


        //    return Json(listadoPedidos, JsonRequestBehavior.AllowGet);
        //}

        public void inicializar_barra_superior()
        {
            Session["Postulantes"] = Web.Code52.i18n.Language.Postulantes;
            Session["Postulante"] = Web.Code52.i18n.Language.Postulante;
            Session["evaluarPostulantes"] = Web.Code52.i18n.Language.evaluarPostulantes;
            Session["PostulantesporBusqueda"] = Web.Code52.i18n.Language.PostulantesporBusqueda;

            Session["Avisos"] = Web.Code52.i18n.Language.Avisos;
            Session["GestionarAvisos"] = Web.Code52.i18n.Language.GestionarAvisos;

            Session["Campanias"] = Web.Code52.i18n.Language.Campanias;
            Session["GenerarCampania"] = Web.Code52.i18n.Language.GenerarCampania;

            Session["Productos"] = Web.Code52.i18n.Language.Productos;
            Session["NuevoProducto"] = Web.Code52.i18n.Language.NuevoProducto;
            Session["Administracion"] = Web.Code52.i18n.Language.Administracion;
            Session["Consultor"] = Web.Code52.i18n.Language.Consultor;
            Session["NuevaBusqueda"] = Web.Code52.i18n.Language.NuevaBusqueda;
            Session["GestionarAvisos"] = Web.Code52.i18n.Language.GestionarAvisos;
            
            Session["AdminPerfil"] = Web.Code52.i18n.Language.AdminPerfil;
            Session["Registrarse"] = Web.Code52.i18n.Language.Registrarse;
            Session["IniciarSesion"] = Web.Code52.i18n.Language.IniciarSesion;

            Session["AltaCV"] = Web.Code52.i18n.Language.AltaCV;
            Session["CerrarSesion"] = Web.Code52.i18n.Language.CerrarSesion;
            Session["Pedidos"] = Web.Code52.i18n.Language.Pedidos;
            Session["ListadoPedidos"] = Web.Code52.i18n.Language.ListadoPedidos;
            Session["ListadoPedidosAConfirmar"] = Web.Code52.i18n.Language.ListadoPedidosAConfirmar;
            Session["Confirmados"] = Web.Code52.i18n.Language.Confirmados;
            Session["ListadoPedidosCancelados"] = Web.Code52.i18n.Language.ListadoPedidosCancelados;
            Session["Facturacion"] = Web.Code52.i18n.Language.Facturacion;
            Session["Factura"] = Web.Code52.i18n.Language.Factura;
            Session["Bitacora"] = Web.Code52.i18n.Language.Bitacora;
            Session["Busqueda"] = Web.Code52.i18n.Language.Busqueda;
            Session["AltaEmpleado"] = Web.Code52.i18n.Language.AltaEmpleado;
            Session["AltaCliente"] = Web.Code52.i18n.Language.altaCliente;
            Session["ListadoFactura"] = Web.Code52.i18n.Language.ListadoFactura;
            
        }

        public void inicializar_barra_lateral()
        {
            Session["Modulos"] = Web.Code52.i18n.Language.Modulos;
            Session["DatosPersonales"] = Web.Code52.i18n.Language.DatosPersonales;
            Session["EstudiosFormales"] = Web.Code52.i18n.Language.EstudiosFormales;
            Session["ExperienciaLaboral"] = Web.Code52.i18n.Language.ExperienciaLaboral;

            Session["Secciones"] = Web.Code52.i18n.Language.Secciones;
            Session["AntenasHF"] = Web.Code52.i18n.Language.AntenasHF;
            Session["AntenasVHF"] = Web.Code52.i18n.Language.AntenasVHF;
            Session["AntenasHilo"] = Web.Code52.i18n.Language.AntenasHilo;
            Session["Torres"] = Web.Code52.i18n.Language.Torres;
            Session["Rotores"] = Web.Code52.i18n.Language.Rotores;
            Session["Accesorios"] = Web.Code52.i18n.Language.Accesorios;
            Session["Novedades"] = Web.Code52.i18n.Language.Novedades;
            Session["Promociones"] = Web.Code52.i18n.Language.Promociones;
            Session["AltaCV"] = Web.Code52.i18n.Language.AltaCV;
            
        }

        public void inicializar_contenido()
        {
            Session["ListadoProductosVigentes"] = Web.Code52.i18n.Language.ListadoProductosVigentes;
            Session["MontoTotal"] = Web.Code52.i18n.Language.MontoTotal;
            Session["NroPedido"] = Web.Code52.i18n.Language.NroPedido;
            Session["Fecha"] = Web.Code52.i18n.Language.Fecha;
            Session["Estado"] = Web.Code52.i18n.Language.Estado;
            Session["CantidadProductos"] = Web.Code52.i18n.Language.CantidadProductos;
            Session["NombreCliente"] = Web.Code52.i18n.Language.NombreCliente;
            Session["direccion"] = Web.Code52.i18n.Language.direccion;
            Session["PrecioTotal"] = Web.Code52.i18n.Language.PrecioTotal;
            Session["DatosDeCliente"] = Web.Code52.i18n.Language.DatosDeCliente;
            Session["opcionDePago"] = Web.Code52.i18n.Language.opcionDePago;
            Session["telefono"] = Web.Code52.i18n.Language.telefono;
            Session["email"] = Web.Code52.i18n.Language.email;
            Session["ListadoDePedidos"] = Web.Code52.i18n.Language.ListadoDePedidos;
            Session["ListadoDePedidosAConfirmar"] = Web.Code52.i18n.Language.ListadoDePedidosAConfirmar;
            Session["ListadoPedidosConfirmados"] = Web.Code52.i18n.Language.ListadoPedidosConfirmados;
            Session["ListadoDePedidosCancelados"] = Web.Code52.i18n.Language.ListadoDePedidosCancelados;
            Session["ListadoDePedidosFinalizados"] = Web.Code52.i18n.Language.ListadoDePedidosFinalizados;
            Session["StockConfirmado"] = Web.Code52.i18n.Language.StockConfirmado;
            Session["Buscar"] = Web.Code52.i18n.Language.Buscar;
            Session["CostoPublico"] = Web.Code52.i18n.Language.CostoPublico;

        }
 
    }
}

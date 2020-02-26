using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BI;
using SL.Bitacora;
using SL.Excepciones;

namespace Web.Controllers
{
    public class SeccionesController : Controller
    {
        INEGGestionServicio intNegGestionServicio = new NEGGestionServicio();
        INEGGestionCV intNegGestionCV = new NEGGestionCV();

        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();


        [HttpGet]
        public ActionResult DatosPersonales()
        {

            List<ClsDatosPersonales> listadoDatosPersonales = new List<BI.ClsDatosPersonales>();

            try
            {
                listadoDatosPersonales = intNegGestionCV.obtenerDatosPersonales();


                //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
                if (Models.ListadosGlobales.listadoServicios.Count > 0)
                {
                    foreach (ClsServicio oServicio in Models.ListadosGlobales.listadoServicios)
                    {
                        //if (oServicio.sesionId == Session.SessionID)
                        //{
                        ViewBag.Cantidad = oServicio.listaServicios.Count();
                        break;
                        //}
                        //else
                        //{
                        //    ViewBag.Cantidad = 0;
                        //}

                    }
                }
                else
                {
                    ViewBag.Cantidad = 0;
                }
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View(listadoDatosPersonales);
        }


        [HttpGet]
        public ActionResult AntenasHF()
        {
         
            List<ClsServicio> listadoServicios = new List<BI.ClsServicio>();

            try
            {
                 listadoServicios = intNegGestionServicio.obtenerServicios();


                //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
                if (Models.ListadosGlobales.listadoServicios.Count > 0)
                {
                    foreach (ClsServicio oServicio in Models.ListadosGlobales.listadoServicios)
                    {
                        //if (oServicio.sesionId == Session.SessionID)
                        //{
                        ViewBag.Cantidad = oServicio.listaServicios.Count();
                        break;
                        //}
                        //else
                        //{
                        //    ViewBag.Cantidad = 0;
                        //}

                    }
                }
                else
                {
                    ViewBag.Cantidad = 0;
                }
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View(listadoServicios);
        }


        public ActionResult Busqueda()
        {
            this.inicializar_contenido();

            List<ClsBusqueda> listadoBusquedas = new List<ClsBusqueda>();

            try
            {

                listadoBusquedas = intNegGestionServicio.obtenerBusquedas();
                    

            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View(listadoBusquedas);
        }

        public ActionResult buscarBusquedas(string pValor)
        {
            List<ClsBusqueda> listadoBusquedas = new List<ClsBusqueda>();

            try
            {
                if (pValor != "")
                {
                    listadoBusquedas = intNegGestionServicio.buscarBusquedas(pValor);
                }
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View("Busqueda", listadoBusquedas);
        }

        //[HttpGet]
        //public ActionResult AntenasVHF()
        //{
        //    string pSeccion = "AntenasVHF";
        //    List<BI.Producto> listadoProductos = new List<BI.Producto>();


        //    try
        //    {

        //        listadoProductos = intNegGestionPedido.obtenerProductosFiltrados(pSeccion);

        //        //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
        //        if (Models.ListadosGlobales.listadoPedidos.Count > 0)
        //        {
        //            foreach (Pedido oPedido in Models.ListadosGlobales.listadoPedidos)
        //            {
        //                if (oPedido.sesionId == Session.SessionID)
        //                {
        //                    ViewBag.Cantidad = oPedido.listaProductos.Count();
        //                    break;
        //                }
        //                else
        //                {
        //                    ViewBag.Cantidad = 0;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Cantidad = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }


        //    return View(listadoProductos);
        //}

        //[HttpGet]
        //public ActionResult AntenasHilo()
        //{
        //    string pSeccion = "AntenasHilo";
        //    List<BI.Producto> listadoProductos = new List<BI.Producto>();

        //    try
        //    {

        //        listadoProductos = intNegGestionPedido.obtenerProductosFiltrados(pSeccion);

        //        //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
        //        if (Models.ListadosGlobales.listadoPedidos.Count > 0)
        //        {
        //            foreach (Pedido oPedido in Models.ListadosGlobales.listadoPedidos)
        //            {
        //                if (oPedido.sesionId == Session.SessionID)
        //                {
        //                    ViewBag.Cantidad = oPedido.listaProductos.Count();
        //                    break;
        //                }
        //                else
        //                {
        //                    ViewBag.Cantidad = 0;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Cantidad = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    return View(listadoProductos);
        //}

        //[HttpGet]
        //public ActionResult Torres()
        //{
        //    string pSeccion = "Torres";
        //    List<BI.Producto> listadoProductos = new List<BI.Producto>();

        //    try
        //    {

        //        listadoProductos = intNegGestionPedido.obtenerProductosFiltrados(pSeccion);

        //        //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
        //        if (Models.ListadosGlobales.listadoPedidos.Count > 0)
        //        {
        //            foreach (Pedido oPedido in Models.ListadosGlobales.listadoPedidos)
        //            {
        //                if (oPedido.sesionId == Session.SessionID)
        //                {
        //                    ViewBag.Cantidad = oPedido.listaProductos.Count();
        //                    break;
        //                }
        //                else
        //                {
        //                    ViewBag.Cantidad = 0;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Cantidad = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }
        //    return View(listadoProductos);
        //}

        //[HttpGet]
        //public ActionResult Rotores()
        //{
        //    string pSeccion = "Rotores";
        //    List<BI.Producto> listadoProductos = new List<BI.Producto>();

        //    try
        //    {

        //        listadoProductos = intNegGestionPedido.obtenerProductosFiltrados(pSeccion);

        //        //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
        //        if (Models.ListadosGlobales.listadoPedidos.Count > 0)
        //        {
        //            foreach (Pedido oPedido in Models.ListadosGlobales.listadoPedidos)
        //            {
        //                if (oPedido.sesionId == Session.SessionID)
        //                {
        //                    ViewBag.Cantidad = oPedido.listaProductos.Count();
        //                    break;
        //                }
        //                else
        //                {
        //                    ViewBag.Cantidad = 0;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Cantidad = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }


        //    return View(listadoProductos);
        //}

        //[HttpGet]
        //public ActionResult Accesorios()
        //{
        //    string pSeccion = "Accesorios";
        //    List<BI.Producto> listadoProductos = new List<BI.Producto>();

        //    try
        //    {

        //        listadoProductos = intNegGestionPedido.obtenerProductosFiltrados(pSeccion);

        //        //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
        //        if (Models.ListadosGlobales.listadoPedidos.Count > 0)
        //        {
        //            foreach (Pedido oPedido in Models.ListadosGlobales.listadoPedidos)
        //            {
        //                if (oPedido.sesionId == Session.SessionID)
        //                {
        //                    ViewBag.Cantidad = oPedido.listaProductos.Count();
        //                    break;
        //                }
        //                else
        //                {
        //                    ViewBag.Cantidad = 0;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Cantidad = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    return View(listadoProductos);
        //}

        //[HttpGet]
        //public ActionResult Promociones()
        //{
        //    List<BI.Promocion> listadoPromociones = new List<BI.Promocion>();
        //    this.inicializar_contenido();

        //    try
        //    {
        //        listadoPromociones = intNegGestionPedido.obtenerPromocionesActivas();

        //        //Para la cantidad al lado del usuario USUARIO(CANTIDAD)
        //        if (Models.ListadosGlobales.listadoPedidos.Count > 0)
        //        {
        //            foreach (Pedido oPedido in Models.ListadosGlobales.listadoPedidos)
        //            {
        //                if (oPedido.sesionId == Session.SessionID)
        //                {
        //                    ViewBag.Cantidad = oPedido.listaProductos.Count();
        //                    break;
        //                }
        //                else
        //                {
        //                    ViewBag.Cantidad = 0;
        //                }

        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Cantidad = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }


        //    return View(listadoPromociones);
        //}


        public void inicializar_contenido()
        {
            Session["Busqueda"] = Web.Code52.i18n.Language.Busqueda;
            Session["FechaPublicacion"] = Web.Code52.i18n.Language.FechaPublicacion;
            Session["Descripcion"] = Web.Code52.i18n.Language.Descripcion;
            Session["Referencia"] = Web.Code52.i18n.Language.Referencia;
            //Session["Descuento"] = Web.Code52.i18n.Language.Descuento;
            //Session["CostoConDescuento"] = Web.Code52.i18n.Language.CostoConDescuento;

        }
    }
}

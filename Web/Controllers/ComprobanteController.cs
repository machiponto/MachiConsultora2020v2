using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BI;
using BLL;
using Rotativa;
using SL.Excepciones;
using SL.Bitacora;

namespace Web.Controllers
{
    public class ComprobanteController : Controller
    {

        //INEGGestionPedido intNegGestionPedido = new NEGGestionPedido();
        //INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();

        //[HttpGet]
        //public ActionResult Factura(int pIdFactura)
        //{

        //    this.inicializar_contenido();
        //    ViewBag.CostoTotal = 0;
        //    int montoTotal = 0;

        //    Factura oFactura = new Factura();

        //    try
        //    {
        //        oFactura = intNegGestionPedido.obtenerFacturaPorId(pIdFactura);
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    foreach(Producto _prod in oFactura.listaProductos){
            
        //    montoTotal = montoTotal + (int)_prod.costoPublico;
            
        //    }

        //    ViewBag.CostoTotal = montoTotal;

        //    //return View(oFactura);
        //    return new ViewAsPdf(oFactura) { FileName = "Factura.pdf" };
        //}

        //[HttpGet]
        //public ActionResult listadoFacturas()
        //{

        //    this.inicializar_contenido();

        //    List<Factura> listadoFacturas = new List<Factura>();

        //    try 
        //    {
        //        listadoFacturas = intNegGestionPedido.obtenerFacturas();
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    return View(listadoFacturas);
        //}



        public void inicializar_contenido()
        {
            Session["Nombre"] = Web.Code52.i18n.Language.Nombre;
            Session["opcionDePago"] = Web.Code52.i18n.Language.opcionDePago;
            Session["telefono"] = Web.Code52.i18n.Language.telefono;
            Session["email"] = Web.Code52.i18n.Language.email;

            Session["Codigo"] = Web.Code52.i18n.Language.Codigo;
            Session["Categoria"] = Web.Code52.i18n.Language.Categoria;
            Session["Cantidad"] = Web.Code52.i18n.Language.Cantidad;
            Session["CostoPublico"] = Web.Code52.i18n.Language.CostoPublico;

            Session["cliente"]= Web.Code52.i18n.Language.Cliente;
            Session["sucursal"]= Web.Code52.i18n.Language.Sucursal;
            Session["productos"] = Web.Code52.i18n.Language.Productos;
            Session["Factura"] = Web.Code52.i18n.Language.Factura;
            Session["MontoTotal"] = Web.Code52.i18n.Language.MontoTotal;

            Session["Letra"]= Web.Code52.i18n.Language.Letra;
            Session["Numero"]= Web.Code52.i18n.Language.Numero;
            Session["Tipo"]= Web.Code52.i18n.Language.Tipo;
            Session["Estado"]= Web.Code52.i18n.Language.Estado;
            Session["CantidadProductos"] = Web.Code52.i18n.Language.CantidadProductos;



        }
    }
}

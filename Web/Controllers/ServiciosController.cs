using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using BI;
//using BLL;
//using SL.Excepciones;
//using SL.Bitacora;
using System.Xml.Serialization;
using System.IO;

namespace Web.Controllers
{
    public class ServiciosController : Controller
    {
        //INEGGestionServicio intNegGestionServicio = new NEGGestionServicio();
   
        //[HttpPost]
        //public ActionResult ListadoServicios(Servicio oServicio)
        //{

        //    return View();
        //}


        public void inicializar_contenido()
        {
            Session["idPedido"] = Web.Code52.i18n.Language.idPedido;
            Session["Fecha"] = Web.Code52.i18n.Language.Fecha;
            Session["Estado"] = Web.Code52.i18n.Language.Estado;
            Session["NombreCliente"] = Web.Code52.i18n.Language.NombreCliente;
            Session["telefono"] = Web.Code52.i18n.Language.telefono;
            Session["email"] = Web.Code52.i18n.Language.email;
            Session["opcionDePago"] = Web.Code52.i18n.Language.opcionDePago;
            Session["Codigo"] = Web.Code52.i18n.Language.Codigo;
            Session["Categoria"] = Web.Code52.i18n.Language.Categoria;
            Session["Cantidad"] = Web.Code52.i18n.Language.Cantidad;
            Session["CostoPublico"] = Web.Code52.i18n.Language.CostoPublico;
            Session["IDPromocion"] = Web.Code52.i18n.Language.IDPromocion;
            Session["FechaGeneracion"] = Web.Code52.i18n.Language.FechaGeneracion;
            Session["Activo"] = Web.Code52.i18n.Language.Activo;
            Session["Nombre"] = Web.Code52.i18n.Language.Nombre;
            Session["Descripcion"] = Web.Code52.i18n.Language.Descripcion;
            Session["Descuento"] = Web.Code52.i18n.Language.Descuento;
            Session["PrecioTotal"] = Web.Code52.i18n.Language.PrecioTotal;

            Session["DetalleDePedido"] = Web.Code52.i18n.Language.DetalleDePedido;
            Session["DatosDeCliente"] = Web.Code52.i18n.Language.DatosDeCliente;
            Session["ListadoDeProductos"] = Web.Code52.i18n.Language.ListadoDeProductos;
            Session["ListadoDePromociones"] = Web.Code52.i18n.Language.ListadoDePromociones;
            Session["Buscar"] = Web.Code52.i18n.Language.Buscar;
        }
    }
}

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
    public class ServiceLayerController : Controller
    {

        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();

        public ActionResult Bitacora()
        {
            this.inicializar_contenido();

            List<Bitacora> listadoEventos = new List<Bitacora>();

            try
            {

                listadoEventos = interfazServiceLayer.obtenerEventos();

            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View(listadoEventos);
        }

        public ActionResult buscarEventos(string pValor)
        {
            List<Bitacora> listadoEventos = new List<Bitacora>();

            try
            {
                if (pValor != "")
                {
                    listadoEventos = interfazServiceLayer.buscarEventos(pValor);
                }
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View("Bitacora", listadoEventos);
        }

        public void inicializar_contenido()
        {
            Session["Bitacora"] = Web.Code52.i18n.Language.Bitacora;
            Session["Modulo"] = Web.Code52.i18n.Language.Modulo;
            Session["Tipo"] = Web.Code52.i18n.Language.Tipo;
            Session["Fecha"] = Web.Code52.i18n.Language.Fecha;
            Session["Detalle"] = Web.Code52.i18n.Language.Detalle;
        }
    }
}

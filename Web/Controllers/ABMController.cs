using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BI;
using BLL;
using SL.Excepciones;

namespace Web.Controllers
{
    public class ABMController : Controller
    {
        INEGGestionServicio intNegGestionServicio  = new NEGGestionServicio();

        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();
        INEGAbmCliente interfazABMCliente = new NEGAbmCliente();

        [HttpGet]
        public ActionResult verificarUsuario(string pUsuario)
        {
            bool resultado = false;

            try
            {
                resultado = interfazABMCliente.verificarExistenciaUsuario(pUsuario);
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult altaBusqueda()
        {
            this.inicializar_contenido();

            try
            {
                //var listadoPuestos = intNegGestionServicio.obtenerPuestos();
                //ViewBag.Id_Puesto = new SelectList(listadoPuestos, "Id_Puesto", "DescripciónPuesto");
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return View();
        }

        [HttpGet]
        public ActionResult verificarCodigo(string pCodigo)
        {
            bool resultado = false;

            try
            {
                //resultado = interfazABMCliente.verificarExistenciaCodigoProducto(pCodigo);
            }
            catch (Exception ex)
            {
                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult altaBusqueda(ClsBusqueda oBusqueda)
        {
            try
            {
                //int pId_Puesto = Id_Puesto;
                intNegGestionServicio.altaBusqueda(oBusqueda);

                ViewBag.mostrarMensaje = "OK";
                ViewBag.mensaje = "Busqueda generada correctamente";

            }
            catch (Exception ex)
            {
                ViewBag.mostrarMensaje = "ERROR";
                ViewBag.mensaje = "Se produjo un error al generar la Busqueda";

                WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oWExcepcion);
            }


               return View();
        }


        public void inicializar_contenido()
        {
            Session["ListadoProductosVigentes"] = Web.Code52.i18n.Language.ListadoProductosVigentes;
            Session["Tipo"] = Web.Code52.i18n.Language.Tipo;
            Session["Codigo"] = Web.Code52.i18n.Language.Codigo;
            Session["Categoria"] = Web.Code52.i18n.Language.Categoria;
            Session["Detalle"] = Web.Code52.i18n.Language.Detalle;
            Session["Cantidad"] = Web.Code52.i18n.Language.Cantidad;
            Session["Imagen"] = Web.Code52.i18n.Language.Imagen;
            Session["Cancelar"] = Web.Code52.i18n.Language.Cancelar;
            Session["Generar"] = Web.Code52.i18n.Language.Generar;

            Session["NuevoProducto"] = Web.Code52.i18n.Language.NuevoProducto;
            Session["NuevaBusqueda"] = Web.Code52.i18n.Language.NuevaBusqueda;
            Session["Codigo"] = Web.Code52.i18n.Language.Codigo;
            Session["Categoria"] = Web.Code52.i18n.Language.Categoria;
            Session["Detalle"] = Web.Code52.i18n.Language.Detalle;
            Session["Ubicacion"] = Web.Code52.i18n.Language.Ubicacion;
            Session["UbicacionFoto"] = Web.Code52.i18n.Language.UbicacionFoto;
            Session["CostoReal"] = Web.Code52.i18n.Language.CostoReal;
            Session["CostoReposicion"] = Web.Code52.i18n.Language.CostoReposicion;

            Session["FechaPublicacion"] = Web.Code52.i18n.Language.FechaPublicacion;
            Session["Id_Busqueda"] = Web.Code52.i18n.Language.Id_Busqueda;
            Session["Descripcion"] = Web.Code52.i18n.Language.Descripcion;
            Session["Id_Puesto"] = Web.Code52.i18n.Language.Codigo;
            Session["UbicacionFoto"] = Web.Code52.i18n.Language.UbicacionFoto;
            
                   }

    }
}
 //[HttpGet]
        //public ActionResult altaProducto()
        //{
        //    this.inicializar_contenido();

        //    try
        //    {
        //        var listadoCategoriasProducto = intNegGestionPedido.obtenerCategoriasDeProducto();
        //        ViewBag.categoriaProducto = new SelectList(listadoCategoriasProducto, "idCategoria", "nombre");
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    return View();
        //}

      
        //[HttpGet]
        //public ActionResult detalleProducto(Producto oProducto)
        //{

        //    this.inicializar_contenido();

        //    oProducto.cantidad = 0;


        //    return View(oProducto);

        //}

        
      
        //[HttpGet]
        //public ActionResult darBajaProducto(string pCodigo)
        //{

        //    try
        //    {

        //        intNegGestionPedido.bajaProducto(pCodigo);

        //        ViewBag.mostrarMensaje = "OK";
        //        ViewBag.mensaje = "Producto dado de baja correctamente";
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);

        //        ViewBag.mostrarMensaje = "ERROR";
        //        ViewBag.mensaje = "Se produjo un error al dar de baja el Producto";

        //    }

        //    return RedirectToAction("listadoProduccion", "ABM");

        //}
        

        //[HttpPost]
        //public ActionResult altaProducto(Producto oProducto, HttpPostedFileBase file, int categoriaProducto)
        //{

            
        //    try
        //    {

        //        if (ModelState.IsValid)
        //        {
        //            if (file == null)
        //            {
        //                ModelState.AddModelError("File", "Por favor carque un archivo de imagen");
        //            }
        //            else if (file.ContentLength > 0)
        //            {
        //                int MaxContentLength = 1024 * 1024 * 3; //3 MB
        //                string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };
        //                if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
        //                {
        //                    ModelState.AddModelError("File", "EL archivo debe ser del tipo: " + string.Join(", ", AllowedFileExtensions));
        //                }
        //                else if (file.ContentLength > MaxContentLength)
        //                {
        //                    ModelState.AddModelError("File", "El archivo es demasiado grande, el tamaño maximo permitido es: " + MaxContentLength + " MB");
        //                }
        //                else
        //                {

        //                    try
        //                    {
        //                        var fileName = Path.GetFileName(file.FileName);
        //                        var path = Path.Combine(Server.MapPath("~/Content/Productos"), fileName);

        //                        oProducto.ubicacionFoto = fileName;

        //                        file.SaveAs(path);
        //                        ModelState.Clear();

        //                        int pIdCategoriaProducto = categoriaProducto;

        //                        intNegGestionPedido.altaProducto(oProducto, pIdCategoriaProducto);
                                
        //                        var listadoCategoriasProducto = intNegGestionPedido.obtenerCategoriasDeProducto();
        //                        ViewBag.categoriaProducto = new SelectList(listadoCategoriasProducto, "idCategoria", "nombre");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //                        interfazServiceLayer.registrarEvento(oWExcepcion);
        //                    }
        //                }
        //            }
        //        }

        //        ViewBag.mostrarMensaje = "OK";
        //        ViewBag.mensaje = "Producto generado correctamente";

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.mostrarMensaje = "ERROR";
        //        ViewBag.mensaje = "Se produjo un error al generar el Producto";
                
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }




        //    try
        //    {
        //        var listadoCategoriasProducto = intNegGestionPedido.obtenerCategoriasDeProducto();
        //        ViewBag.categoriaProducto = new SelectList(listadoCategoriasProducto, "idCategoria", "nombre");
        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult detalleProducto(Producto oProducto, string pParametro)
        //{

        //    try
        //    {

        //        intNegGestionPedido.generarProduccion(oProducto);

        //    }
        //    catch (Exception ex)
        //    {
        //        WebExcepcion oWExcepcion = new WebExcepcion(ex.Message);
        //        interfazServiceLayer.registrarEvento(oWExcepcion);
        //    }



        //    return RedirectToAction("listadoProduccion", "ABM");

        //}
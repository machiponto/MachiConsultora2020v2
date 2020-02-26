using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;
using DAL;
using SL.Bitacora;
using SL.Excepciones;
using SL.Correo;

namespace BLL
{
    public class NEGGestionServicio : INEGGestionServicio
    {
        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();
        public List<ClsBusqueda> obtenerBusquedas()

        {

            DALBusqueda oDalBusqueda = new DALBusqueda();
            List<ClsBusqueda> listadoBusquedas = new List<ClsBusqueda>();

            try
            {

                listadoBusquedas = oDalBusqueda.obtenerBusquedas();

            }
            catch (Exception)
            {

            }

            return listadoBusquedas;

        }

        public List<ClsBusqueda> buscarBusquedas(string pValor)

        {

            DALBusqueda oDalBusqueda = new DALBusqueda();
            List<ClsBusqueda> listadoBusquedas = new List<ClsBusqueda>();

            try
            {

                //listadoBusquedas = oDalBusqueda.obtenerBusquedas();
                listadoBusquedas = oDalBusqueda.buscarBusquedas(pValor);

            }
            catch (Exception)
            {

            }

            return listadoBusquedas;

        }

        public List<ClsServicio> obtenerServicios()
        {

            List<ClsServicio> listadoServicios = new List<ClsServicio>();
            List<ClsServicio> listadoServiciosActivos = new List<ClsServicio>();
            DALServicio oDalServicio = new DALServicio();

            try
            {
                listadoServicios = oDalServicio.obtenerServicios();

                foreach (ClsServicio _serv in listadoServicios)
                {

                    if (_serv.Activo == true)
                    {
                        listadoServiciosActivos.Add(_serv);
                    }
                }


                //listadoServiciosActivos = this.actualizarCostosEnProductos(listadoServiciosActivos);
            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }

            return listadoServiciosActivos;
        }

        public List<ClsPuestos> obtenerPuestos()
        {
            DALPuesto oDalPuesto = new DALPuesto();
            List<ClsPuestos> listadoPuestos = new List<ClsPuestos>();

            try
            {

                listadoPuestos = oDalPuesto.obtenerPuestos();

            }
            catch (Exception)
            {

            }

            return listadoPuestos;

        }

       
        public void altaBusqueda(ClsBusqueda oBusqueda)
        //public void altaBusqueda(ClsBusqueda oBusqueda, int pId_Puesto)
        {

            DALBusqueda oDalBusqueda = new DALBusqueda();
            //DALPuesto oDalPuesto = new DALPuesto();
            //ClsBusqueda oBusqueda = new Busqueda();

            try
            {
                //oPuesto = oDalPuesto.obtenerPuestos(pId_Puesto);
                oBusqueda.Id_Busqueda = oBusqueda.Id_Busqueda;
                oBusqueda.FechaPublicacion = DateTime.Now;
                oBusqueda.Descripcion = oBusqueda.Descripcion;
                oBusqueda.Referencia = oBusqueda.Referencia;
                oBusqueda.activa = oBusqueda.activa;

                oDalBusqueda.altaBusqueda(oBusqueda);


                string pDetalle = "Se genero la Busqueda " + oBusqueda.Referencia + " satisfactoriamente.";
                string pModulo = "BLL";
                interfazServiceLayer.registrarEventoNegocio(pDetalle, pModulo);

            }
            catch (DalExcepcion ex)
            {
                DalExcepcion oDExcepcion = new DalExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oDExcepcion);
            }
            catch (Exception ex)
            {
                BllExcepcion oBExcepcion = new BllExcepcion(ex.Message);
                interfazServiceLayer.registrarEvento(oBExcepcion);
            }
        
        }
    }
}

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
    public class NEGGestionCV : INEGGestionCV 
    {
        INEGServiceLayer interfazServiceLayer = new NEGServiceLayer();

        public List<ClsDatosPersonales> obtenerDatosPersonales()
        {

            List<ClsDatosPersonales> listadoDatosPersonales = new List<ClsDatosPersonales>();
          
            DALCV  oDalServicio = new DALCV();

            try
            {
                listadoDatosPersonales = oDalServicio.obtenerDatosPersonales();

                foreach (ClsDatosPersonales _dPers in listadoDatosPersonales)
                {

                    //if (_serv.Activo == true)
                    //{
                    //    listadoDatosPersonales.Add(_serv);
                    //}

                    listadoDatosPersonales.Add(_dPers);
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

            return listadoDatosPersonales;
        }
    }
}

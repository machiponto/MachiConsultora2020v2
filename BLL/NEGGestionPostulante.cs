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
    public class NEGGestionPostulante : INEGGestionPostulante
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

        public List<ClsBusqueda> obtenerBusquedas(int pValor)
        {

            DALBusqueda oDalBusqueda = new DALBusqueda();
            List<ClsBusqueda> listadoEventos = new List<ClsBusqueda>();

            try
            {

                //listadoEventos = oDalBusqueda.obtenerBusquedas(pValor);
                listadoEventos = oDalBusqueda.obtenerBusquedas();
            }
            catch (Exception)
            {

            }

            return listadoEventos;

        }

        public List<ClsBusqueda> CandidatosporBusqueda(string pValor)

        {

            DALBusqueda oDalBusqueda = new DALBusqueda();
            List<ClsBusqueda> listadoBusquedas = new List<ClsBusqueda>();

            try
            {

                //listadoBusquedas = oDalBusqueda.obtenerBusquedas();
                listadoBusquedas = oDalBusqueda.CandidatosporBusqueda(pValor);

            }
            catch (Exception)
            {

            }

            return listadoBusquedas;

        }

        public List<ClsBusqueda> buscarPostulantesID(int pValor)

        {

            DALBusqueda oDalBusqueda = new DALBusqueda();
            List<ClsBusqueda> listadoBusquedas = new List<ClsBusqueda>();

            try
            {

                //listadoBusquedas = oDalBusqueda.obtenerBusquedas();
                listadoBusquedas = oDalBusqueda.buscarPostulantesID(pValor);

            }
            catch (Exception)
            {

            }

            return listadoBusquedas;

        }

    }
}

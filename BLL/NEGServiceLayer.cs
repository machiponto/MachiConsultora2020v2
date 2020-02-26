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
    public class NEGServiceLayer : INEGServiceLayer
    {

        public void registrarEvento(DalExcepcion oDExcepcion)
        {
            DALBitacora oDalBitacora = new DALBitacora();
            SL.Bitacora.Bitacora oBitacora = new SL.Bitacora.Bitacora();

            try
            {
                oBitacora.fecha = DateTime.Now;
                oBitacora.modulo = "DAL";
                oBitacora.detalle = oDExcepcion.Message;
                oBitacora.tipo = "Critical";

                oDalBitacora.registrarEvento(oBitacora);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void registrarEvento(BllExcepcion oBExcepcion)
        {

            DALBitacora oDalBitacora = new DALBitacora();
            SL.Bitacora.Bitacora oBitacora = new SL.Bitacora.Bitacora();

            try
            {
                oBitacora.fecha = DateTime.Now;
                oBitacora.modulo = "BLL";
                oBitacora.detalle = oBExcepcion.Message;
                oBitacora.tipo = "Critical";

                oDalBitacora.registrarEvento(oBitacora);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void registrarEvento(WebExcepcion oWExcepcion)
        {

            DALBitacora oDalBitacora = new DALBitacora();
            SL.Bitacora.Bitacora oBitacora = new SL.Bitacora.Bitacora();

            try
            {
                oBitacora.fecha = DateTime.Now;
                oBitacora.modulo = "WEB";
                oBitacora.detalle = oWExcepcion.Message;
                oBitacora.tipo = "Critical";

                oDalBitacora.registrarEvento(oBitacora);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<SL.Bitacora.Bitacora> obtenerEventos()
        {

            DALBitacora oDalBitacora = new DALBitacora();
            List<SL.Bitacora.Bitacora> listadoEventos = new List<SL.Bitacora.Bitacora>();

            try
            {

                listadoEventos = oDalBitacora.obtenerEventos();

            }
            catch (Exception)
            {

            }

            return listadoEventos;

        }

        public List<SL.Bitacora.Bitacora> buscarEventos(string pValor)
        {

            DALBitacora oDalBitacora = new DALBitacora();
            List<SL.Bitacora.Bitacora> listadoEventos = new List<SL.Bitacora.Bitacora>();

            try
            {

                listadoEventos = oDalBitacora.obtenerEventosFiltrados(pValor);

            }
            catch (Exception)
            {

            }

            return listadoEventos;

        }

        public void registrarEventoNegocio(string pDetalle, string pModulo)
        {

            DALBitacora oDalBitacora = new DALBitacora();
            SL.Bitacora.Bitacora oBitacora = new SL.Bitacora.Bitacora();
            try
            {
                oBitacora.fecha = DateTime.Now;
                oBitacora.tipo = "Informational";
                oBitacora.modulo = pModulo;
                oBitacora.detalle = pDetalle;
                oDalBitacora.registrarEvento(oBitacora);

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        public void enviarCorreo(ClsCliente oCliente, string pAsunto, string pCuerpoMail)
        {

            try
            {
                Mail oMail = new Mail(oCliente.mail, pAsunto, pCuerpoMail);
                CorreoElectronico oCorreoElectronico = new CorreoElectronico();
                oCorreoElectronico.EnviarCorreo(oMail);

            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}


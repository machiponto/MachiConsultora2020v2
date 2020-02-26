using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BI;
using SL.Bitacora;
using SL.Excepciones;
using SL.Correo;

namespace BLL
{
    public interface INEGServiceLayer
    {

        //Bitacora de Excepciones
        void registrarEvento(DalExcepcion oDExcepcion);
        void registrarEvento(BllExcepcion oBExcepcion);
        void registrarEvento(WebExcepcion oWExcepcion);



        //Obtención de eventos
        List<Bitacora> obtenerEventos();
        List<Bitacora> buscarEventos(string pValor);
        void registrarEventoNegocio(string pDetalle, string pModulo);

        //Envío de mails
        void enviarCorreo(ClsCliente oCliente, string pAsunto, string pCuerpoMail);


    }
}

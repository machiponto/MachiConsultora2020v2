using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SL.Correo
{
    public class Mail
    {

        public Mail(string pDest, string pAsunto, string pCuerpoMail)
        {
            //Valores Fijos
            this.cuentaOrigen = "machiconsultora@gmail.com";
            this.contrasena = "uai05uai";
            this.host = "smtp.gmail.com";

            //Valores dinámicos
            this.destinatario = pDest;
            this.asunto = pAsunto;
            this.cuerpoMail = pCuerpoMail;

        }


        //Propiedades

        public string destinatario { get; set; }
        public string asunto { get; set; }
        public string destinatarioCopiaOculta { get; set; }
        public string cuerpoMail { get; set; }

        public string cuentaOrigen { get; set; }
        public string contrasena { get; set; }
        public string host { get; set; }



    }
}

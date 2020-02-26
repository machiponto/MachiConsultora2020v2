using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace SL.Correo
{
    public class CorreoElectronico
    {

        public void EnviarCorreo(Mail oMail)
        {
            //Extraído de http://oscarsotorrio.com/post/2011/01/22/Envio-de-correo-en-NET-con-CSharp.aspx

            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            MailMessage mmsg = new MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario
            mmsg.To.Add(oMail.destinatario);

            //Asunto
            mmsg.Subject = oMail.asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            //Opcional
            if (oMail.destinatarioCopiaOculta != null)
            {
                mmsg.Bcc.Add(oMail.destinatarioCopiaOculta);
            }

            //Cuerpo del Mensaje
            mmsg.Body = oMail.cuerpoMail;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new MailAddress(oMail.cuentaOrigen);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            SmtpClient cliente = new SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials = new NetworkCredential(oMail.cuentaOrigen, oMail.contrasena);

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = oMail.host;


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
            }
        }

    }
}

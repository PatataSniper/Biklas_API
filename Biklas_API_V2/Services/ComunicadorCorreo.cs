using Biklas_API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Biklas_API_V2.Services
{
    public class ComunicadorCorreo
    {
        public static void EnviarCorreoRecuperacionContra(Usuarios usr)
        {
            // Preparamos dirección, contraseña y contenido del correo
            string direcc = usr.CorreoElectronico;
            string contra = Encriptador.Decrypt(usr.Contraseña, Encriptador.Llave);
            string contCorreo = PrepContRecuperaContra(contra);

            // Preparamos correo electrónico
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            msg.From = new MailAddress(Credenciales.CORREO_ELECTRONICO_COM);
            msg.To.Add(new MailAddress(direcc));
            msg.Subject = "Servicio de recuperación de contraseña";
            msg.IsBodyHtml = true; //to make message body as html  
            msg.Body = contCorreo;

            // Preparamos cliente SMTP
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("biklasservicios@gmail.com", Credenciales.CONTRA_CORREO_ELECTRONICO_COM);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            // Enviamos correo
            smtp.Send(msg);
        }

        /// <summary>
        /// Prepara el contenido del correo de recuperación de contraseña
        /// </summary>
        /// <param name="contra"></param>
        /// <returns></returns>
        private static string PrepContRecuperaContra(string contra)
        {
            return $"<font>Tu contraseña es '{contra}', no la compartas con nadie</font>";
        }
    }
}
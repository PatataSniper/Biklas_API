using Biklas_API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Biklas_API_V2.Services
{
    public class ComunicadorCorreo : IComunicadorCorreo
    {
        IEncriptador _encriptador;
        public ComunicadorCorreo(IEncriptador encriptador)
        {
            _encriptador = encriptador;
        }

        public void EnviarCorreoRecuperacionContra(Usuarios usr)
        {
            // Preparamos dirección, contraseña y contenido del correo
            string direcc = usr.CorreoElectronico;
            string contra = _encriptador.Desencriptar(usr.Contraseña, _encriptador.Llave);
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
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(Credenciales.CORREO_ELECTRONICO_COM, Credenciales.CONTRA_CORREO_ELECTRONICO_COM);

            // Enviamos correo
            smtp.Send(msg);
        }

        //public void SendMail()
        //{
        //    // Prepare mail
        //    MailMessage msg = new MailMessage();
        //    SmtpClient smtp = new SmtpClient();
        //    msg.From = new MailAddress("example@gmail.com");
        //    msg.To.Add(new MailAddress("examplereceiver@gmail.com"));
        //    msg.Subject = "Example subject";
        //    msg.IsBodyHtml = true; //to make message body as html  
        //    msg.Body = "Hi, this is the mail content";

        //    // Prepare client SMTP
        //    smtp.Port = 587;
        //    smtp.Host = "smtp.gmail.com"; //for gmail host  
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new NetworkCredential("example@gmail.com", "passwordExample");
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        //    // Send mail
        //    smtp.Send(msg);
        //}

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
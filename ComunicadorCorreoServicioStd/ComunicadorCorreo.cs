using EncriptadorServicioStd;
using System.Net;
using System.Net.Mail;

namespace ComunicadorCorreoServicioStd
{
    public class ComunicadorCorreo : IComunicadorCorreo
    {
        IEncriptador _encriptador;
        public ComunicadorCorreo(IEncriptador encriptador)
        {
            _encriptador = encriptador;
        }

        public void EnviarCorreoRecuperacionContra(string emailDest, 
            string contraDest, 
            string emailOrig, 
            string contraOrig)
        {
            // Preparamos dirección, contraseña y contenido del correo
            string direcc = emailDest;
            contraDest = _encriptador.Desencriptar(contraDest, _encriptador.Llave);
            string contCorreo = PrepContRecuperaContra(contraDest);

            // Preparamos correo electrónico
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            msg.From = new MailAddress(emailOrig);
            msg.To.Add(new MailAddress(direcc));
            msg.Subject = "Servicio de recuperación de contraseña";
            msg.IsBodyHtml = true; //to make message body as html  
            msg.Body = contCorreo;

            // Preparamos cliente SMTP

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(emailOrig, contraOrig);

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
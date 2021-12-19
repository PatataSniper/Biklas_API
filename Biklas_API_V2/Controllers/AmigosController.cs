using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Biklas_API_V2.Models;

namespace Biklas_API_V2.Controllers
{
    public class AmigosController : BKBaseApiController
    {
        // GET: ObtenerAmigosRelacionados
        [HttpGet]
        public IHttpActionResult ObtenerAmigosRelacionados(int idUsuario)
        {
            // Get the user from database
            Usuarios usr = db.Usuarios.Find(idUsuario);

            // Return the related friends as response
            List<object> listAmigos = new List<object>();
            foreach(Amigos amigo in usr.Amigos)
            {
                // We parse the friends and related users objects to 
                // anonimous objects to avoid an infinite loop. The name
                // of the anonimous object properties should match the
                // names declared in the interface 'amigo' in the file
                // 'amigos-context.ts' (client).
                listAmigos.Add(new
                {
                    id = amigo.IdAmigo,
                    nombre = amigo.Usuarios1.Nombre,
                    apellidos = amigo.Usuarios1.Apellidos,
                    fechaNacimiento = amigo.Usuarios1.FechaNacimiento,
                    kmRecorridos = amigo.Usuarios1.KmRecorridos,
                    amigosDesde = amigo.FechaRelacion
                });
            }

            return Json( listAmigos );
        }
    }
}
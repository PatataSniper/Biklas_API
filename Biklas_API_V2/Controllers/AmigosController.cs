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
            foreach (Amigos amigo in usr.Amigos)
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
                    nombreUsuario = amigo.Usuarios1.NombreUsuario,
                    fechaNacimiento = amigo.Usuarios1.FechaNacimiento,
                    kmRecorridos = amigo.Usuarios1.KmRecorridos,
                    amigosDesde = amigo.FechaRelacion
                });
            }

            return Json(listAmigos);
        }

        [HttpDelete]
        [ActionName("EliminarAmigo")]
        public IHttpActionResult EliminarAmigo(Amigos relacion)
        {
            try
            {
                // Obtenemos los identificadores de relación del objeto recibido como parámetro
                int idUsuario = relacion.IdUsuario;
                int idAmigo = relacion.IdAmigo;

                // Obtenemos la relaciones de amistad entre ambos usuarios
                List<Amigos> relaciones = db.Amigos
                    .Where(a => a.IdUsuario == idUsuario && a.IdAmigo == idAmigo
                    || a.IdUsuario == idAmigo && a.IdAmigo == idUsuario)
                    .ToList();

                // Las eliminamos de la base de datos
                db.Amigos.RemoveRange(relaciones);
                if (db.SaveChanges() > 0)
                {
                    return Json(true);
                }

                throw new Exception("Error al actualizar las entradas en la base de datos");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [ActionName("AgregarAmigo")]
        public IHttpActionResult AgregarAmigo(Amigos relacion)
        {
            try
            {
                // Obtenemos los identificadores de relación del objeto recibido como parámetro
                int idUsuario = relacion.IdUsuario;
                int idAmigo = relacion.IdAmigo;

                // Creamos y agregamos la relación de amistad entre ambos usuarios
                db.Amigos.AddRange(new List<Amigos>()
                {
                    // Dos registros, la relación es bilateral. El constructor configura la 
                    // fecha de creación
                    new Amigos(idUsuario, idAmigo),
                    new Amigos(idAmigo, idUsuario)
                });

                if (db.SaveChanges() > 0)
                {
                    return Json(true);
                }

                throw new Exception("Error al actualizar las entradas en la base de datos");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
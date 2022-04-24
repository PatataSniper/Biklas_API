using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Biklas_API_V2.Models;

namespace Biklas_API_V2.Controllers
{
    public class RutasController : BKBaseApiController
    {
        [HttpGet]
        public IHttpActionResult ObtenerRutasRelacionadas(int idUsuario)
        {
            try
            {
                // Obtenemos al usuario de la base de datos
                Usuarios usr = db.Usuarios.Find(idUsuario);

                if(usr == null)
                {
                    throw new Exception("Usuario no existe en la base de datos");
                }

                // Devuelve las rutas relacionadas. Convertimos las rutas a objetos 
                // anónimos para evitar ciclos infinitos. El nombre de las propiedades
                // de los objetos anónimos deberán cuadrar con los nombres las propiedades
                // declaradas en el cliente
                return Json(usr.Rutas.Select(r => new
                {
                    id = r.IdRuta,
                    nombre = r.Nombre,
                    distancia = "10 km",
                    fechaCreacion = r.FechaCreacion.Date.ToString()
                }));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Rutas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRutas(int id, Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rutas.IdRuta)
            {
                return BadRequest();
            }

            db.Entry(rutas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rutas
        [ResponseType(typeof(Rutas))]
        public IHttpActionResult PostRutas(Rutas rutas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rutas.Add(rutas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RutasExists(rutas.IdRuta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rutas.IdRuta }, rutas);
        }

        // DELETE: api/Rutas/5
        [ResponseType(typeof(Rutas))]
        public IHttpActionResult DeleteRutas(int id)
        {
            Rutas rutas = db.Rutas.Find(id);
            if (rutas == null)
            {
                return NotFound();
            }

            db.Rutas.Remove(rutas);
            db.SaveChanges();

            return Ok(rutas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RutasExists(int id)
        {
            return db.Rutas.Count(e => e.IdRuta == id) > 0;
        }
    }
}
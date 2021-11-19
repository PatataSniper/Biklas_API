using Biklas_API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biklas_API_V2.Controllers
{
    public class UsuariosController : BKBaseApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<Usuarios> usuarios = db.Usuarios.ToList();
            List<object> result = new List<object>();
            result.AddRange(usuarios.Select(u => new
            {
                u.IdUsuario,
                u.Nombre,
                u.Apellidos,
                u.NombreUsuario,
                u.Contraseña,
                u.CorreoElectronico,
                u.IdRol
            }));

            return Json(result);
        }

        //GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Json(new
            {
                usr = new
                {
                    usuario.IdUsuario,
                    usuario.Nombre,
                    usuario.Apellidos,
                    usuario.NombreUsuario,
                    usuario.Contraseña,
                    usuario.CorreoElectronico,
                    usuario.IdRol
                }
            });
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Utilizará las credenciales del usuario para validar su existencia y acceso al sistema.
        /// Si las credenciales existen y son válidas, devuelve la información del usuario.
        /// </summary>
        /// <param name="identificador">El identificador del usuario (nombre o correo electrónico)</param>
        /// <param name="contra">La contraseña del usuario</param>
        /// <returns>Información del usuario existente en la BD</returns>
        [HttpPost]
        public IHttpActionResult IniciarSesion(string identificador, string contra)
        {
            try
            {
                // Recibimos credenciales con los siguientes datos del usuario
                // Identificador: Puede tratarse del nombre del usuario, o del correo del usuario (Ambos datos
                // son válidos como identificador)
                // Contraseña: La contraseña del usuario
                Usuarios usuario = db.Usuarios
                    .FirstOrDefault(u => u.NombreUsuario == identificador || u.CorreoElectronico == identificador);

                if (usuario == null) throw new Exception("Usuario no existe en la base de datos");

                // El usuario existe, validamos la contraseña
                if (usuario.ValidarContra(contra))
                {
                    // Contraseña válida, éxito en el inicio de sesión, devolvemos información del usuario
                    return Json(new
                    {
                        user = new
                        {
                            usuario.IdUsuario,
                            usuario.Nombre,
                            usuario.Apellidos,
                            usuario.NombreUsuario,
                            usuario.Contraseña,
                            usuario.CorreoElectronico,
                            usuario.IdRol
                        },
                        auth_token = "1" // Token de prueba
                    });
                }

                // Contraseña inválida, fallo en el inicio de sesión
                throw new Exception("Contraseña incorrecta");
            }
            catch (Exception ex)
            {
                return Json(new { err = ex.Message });
            }
        }
    }
}
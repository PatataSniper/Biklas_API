using Biklas_API_V2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biklas_API_V2.Models
{
    public partial class Usuarios
    {
        public const int ID_ROL_POR_DEFECTO = 1; // Administrador por defecto

        public static int NuevoId(BiklasEntities db)
        {
            // Devolvemos el primer id disponible para esta tabla
            return (db.Usuarios?.Max(u => u.IdUsuario) ?? 0) + 1;
        }

        /// <summary>
        /// Validamos que la contraseña recibida como parámetro, sea igual a la contraseña
        /// del usuario
        /// </summary>
        /// <param name="contra">Contraseña a validar</param>
        /// <returns>true si las contraseñas son iguales, de lo contrario, false</returns>
        internal bool ValidarContra(string contra)
        {
            // Es necesario desencriptar la contraseña proveniente de la base de datos
            return Encriptador.Decrypt(Contraseña, Encriptador.Llave) == contra;
        }

        /// <summary>
        /// Indica si el usuario actual tiene relación con el usuario especificado
        /// como parámetro
        /// </summary>
        /// <param name="idUsuario">El id del usuario especificado</param>
        /// <returns></returns>
        internal bool SonAmigos(int idUsuario)
        {
            return Amigos.Any(a => a.IdAmigo == idUsuario);
        }

        internal void NormalizarDatosCreacion(BiklasEntities db)
        {
            NormalizarDatos(db);
        }

        internal void NormalizarDatos(BiklasEntities db)
        {
            // Asignamos identificadores válidos
            IdUsuario = Usuarios.NuevoId(db);
            IdRol = Usuarios.ID_ROL_POR_DEFECTO;

            // Encriptamos contraseña para su almacenamiento en BD
            Contraseña = Encriptador.Encrypt(Contraseña, Encriptador.Llave);
        }
    }
}
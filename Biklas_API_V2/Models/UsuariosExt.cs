using EncriptadorServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace Biklas_API_V2.Models
{
    public partial class Usuarios : BaseModel
    {
        public const int ID_ROL_POR_DEFECTO = 1; // Administrador por defecto

        public Usuarios(BiklasEntities db) : base(db) 
        {

        }

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
        /// <param name="encriptador">Servicio encriptador utilizado para desencriptar la
        /// contraseña proveniente de la base de datos</param>
        /// <returns>true si las contraseñas son iguales, de lo contrario, false</returns>
        public bool ValidarContra(string contra, IEncriptador encriptador)
        {
            // Es necesario desencriptar la contraseña proveniente de la base de datos
            return encriptador.Desencriptar(Contraseña, encriptador.Llave) == contra;
        }

        /// <summary>
        /// Indica si el usuario actual tiene relación con el usuario especificado
        /// como parámetro
        /// </summary>
        /// <param name="idUsuario">El id del usuario especificado</param>
        /// <returns></returns>
        public bool SonAmigos(int idUsuario)
        {
            return Amigos.Any(a => a.IdAmigo == idUsuario);
        }

        /// <summary>
        /// Normaliza los datos de la entidad para su posterior almacenamiento en la 
        /// base de datos. Utilizado durante creación de entidad
        /// </summary>
        /// <param name="encriptador">Servicio de encriptación utilizado para encriptar
        /// la contraseña del usuario</param>
        public void NormalizarDatosCreacion(IEncriptador encriptador)
        {
            // Asignamos identificadores válidos
            IdUsuario = Usuarios.NuevoId(Db);
            IdRol = Usuarios.ID_ROL_POR_DEFECTO;

            NormalizarDatos(encriptador);
        }

        /// <summary>
        /// Normaliza los datos de la entidad para su posterior almacenamiento en la 
        /// base de datos
        /// </summary>
        /// <param name="encriptador">Servicio de encriptación utilizado para encriptar
        /// la contraseña del usuario</param>
        public void NormalizarDatos(IEncriptador encriptador)
        {
            // Encriptamos contraseña para su almacenamiento en BD
            Contraseña = encriptador.Encriptar(Contraseña, encriptador.Llave);
        }
    }
}
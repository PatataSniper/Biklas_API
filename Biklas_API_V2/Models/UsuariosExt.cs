using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biklas_API_V2.Models
{
    public partial class Usuarios
    {
        /// <summary>
        /// Validamos que la contraseña recibida como parámetro, sea igual a la contraseña
        /// del usuario
        /// </summary>
        /// <param name="contra">Contraseña a validar</param>
        /// <returns>true si las contraseñas son iguales, de lo contrario, false</returns>
        internal bool ValidarContra(string contra)
        {
            return Contraseña == contra;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biklas_API_V2.Models
{
    public partial class Amigos
    {
        public Amigos() { }

        public Amigos(int idUsuario, int idAmigo)
        {
            IdUsuario = idUsuario;
            IdAmigo = idAmigo;
            FechaRelacion = DateTime.Now.Date;
        }
    }
}
using Biklas_API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biklas_API_V2.Services
{
    public interface IComunicadorCorreo
    {
        void EnviarCorreoRecuperacionContra(Usuarios usr);
    }
}

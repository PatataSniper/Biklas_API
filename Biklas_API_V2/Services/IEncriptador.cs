using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biklas_API_V2.Services
{
    public interface IEncriptador
    {
        string Llave { get; }

        string Encriptar(string textoPlano, string llave);
        string Desencriptar(string textoCifr, string llave);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biklas_API_V2.Services
{
    public interface ICalculadorRuta
    {
        void CalcularRutaOptima(decimal xIni, decimal yIni, decimal xFin, decimal yFin);
    }
}

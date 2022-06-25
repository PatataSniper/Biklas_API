using Biklas_API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorRutaServicio
{
    public interface ICalculadorRuta
    {
        Rutas CalcularRutaOptima(decimal xIni, decimal yIni, decimal xFin, decimal yFin);
    }
}

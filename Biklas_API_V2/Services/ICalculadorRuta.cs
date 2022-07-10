using Biklas_API_V2.Models;
using Itinero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculadorRutaServicio
{
    public interface ICalculadorRuta
    {
        Route CalcularRutaOptima(Point ini, Point fin);
    }
}

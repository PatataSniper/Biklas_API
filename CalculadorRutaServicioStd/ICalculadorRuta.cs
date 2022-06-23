﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorRutaServicioStd
{
    public interface ICalculadorRuta
    {
        void CalcularRutaOptima(decimal xIni, decimal yIni, decimal xFin, decimal yFin);
    }
}
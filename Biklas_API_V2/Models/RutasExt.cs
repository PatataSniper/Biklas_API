// Clase de extención para entidad de rutas 

namespace Biklas_API_V2.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Biklas_API_V2.Models;
    using System.Collections.Generic;
    using System.Windows;

    public partial class Rutas
    {
        /// <summary>
        /// Devuelve el conjunto de cordenadas (x,y) que describen la ruta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Point> Coordenadas()
        {
            List<Point> coordenadas = new List<Point>();

            // Obtenemos los segmentos de ruta ordenados por posición
            Segmentos[] segementos = this.Segmentos.OrderBy(s => s.Posicion).ToArray();
            
            foreach(Segmentos se in segementos)
            {
                Vertices verF = se.Aristas.Vertices; // Vértice final
                if (se.EsElPrimero)
                {
                    // Obtenemos las coordenadas iniciales y finales del primer segmento. De los
                    // segmentos consiguientes solamente serán necesarias las coordenadas finales
                    Vertices verI = se.Aristas.Vertices1; // Vértice inicial

                    // Agregamos las coordenadas iniciales
                    coordenadas.Add(new Point((double)verI.PosicionX, (double)verI.PosicionY));
                }

                // Agregamos las coordenadas finales
                coordenadas.Add(new Point((double)verF.PosicionX, (double)verF.PosicionY));
            }

            return coordenadas;
        }
    }
}
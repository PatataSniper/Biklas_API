using System;
using System.IO;
using System.Diagnostics;
using OsmSharp.Streams;
using OsmSharp;
using Biklas_API_V2.Models;

namespace CalculadorRutaServicio
{
    public class CalculadorRuta : ICalculadorRuta
    {
        public Rutas CalcularRutaOptima(decimal xIni, decimal yIni, decimal xFin, decimal yFin)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Mapas\";
            using (FileStream fStream = File.OpenRead(@"D:\Documentos\Saul documentos\CUCEI\Proyectos_Modulares\Mapas\mapaAreaReducida2_01.pbf"))
            {
                PBFOsmStreamSource source = new PBFOsmStreamSource(fStream);
                foreach (OsmGeo element in source)
                {
                    Debug.WriteLine(element.ToString());
                }
            }
        }
    }
}
using System;
using OsmSharp.Streams;
using System.Linq;
using System.IO;
using OsmSharp;
using System.Diagnostics;

namespace Biklas_API_V2.Services
{
    public class CalculadorRuta : ICalculadorRuta
    {
        public void CalcularRutaOptima(decimal xIni, decimal yIni, decimal xFin, decimal yFin)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Mapas\";
            using (FileStream fStream = File.OpenRead(@"D:\Documentos\Saul documentos\CUCEI\Proyectos_Modulares\Mapas\mapaAreaReducida2_01.pbf"))
            {
                PBFOsmStreamSource source = new PBFOsmStreamSource(fStream);
                foreach (OsmGeo element in source)
                {
                    System.Diagnostics.Debug.WriteLine(element.ToString());
                }
            }
        }
    }
}
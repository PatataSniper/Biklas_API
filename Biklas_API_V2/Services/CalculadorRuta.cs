using System;
using System.IO;
using System.Diagnostics;
using OsmSharp.Streams;
using OsmSharp;
using Biklas_API_V2.Models;
using System.Windows;
using Itinero;
using Itinero.Osm.Vehicles;
using Itinero.IO.Osm;

namespace CalculadorRutaServicio
{
    public class CalculadorRuta : ICalculadorRuta
    {
        public Route CalcularRutaOptima(Point ini, Point fin)
        {
            var routerDb = new RouterDb();
            using (var stream = new FileInfo(@"D:\Documentos\Saul documentos\CUCEI\Proyectos_Modulares\Mapas\mapaAreaReducida2_01.pbf").OpenRead())
            {
                routerDb.LoadOsmData(stream, Vehicle.Bicycle); // create the network for cars only.
            }

            // create a router.
            var router = new Router(routerDb);

            // get a profile.
            var profile = Vehicle.Bicycle.Fastest(); // the default OSM car profile.

            // create a routerpoint from a location.
            // snaps the given location to the nearest routable edge.
            var start = router.Resolve(profile, (float)ini.X, (float)ini.Y);
            var end = router.Resolve(profile, (float)fin.X, (float)fin.Y);

            // calculate a route.
            Route route = router.Calculate(profile, start, end);

            return route;
        }
    }
}
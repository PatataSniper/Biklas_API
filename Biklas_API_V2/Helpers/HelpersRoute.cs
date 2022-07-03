using Itinero;
using Itinero.LocalGeo;
using System.Collections.Generic;
using System.Linq;

public static class HelpersRoute
{
    /// <summary>
    /// Obtiene un arreglo de coordenadas (ruta) interpretable por un mapa de Google
    /// Maps React a partir de un objeto 'Route'
    /// </summary>
    /// <param name="ruta">Objeto de ruta utilizado como origen de los datos (coordenadas)</param>
    /// <returns></returns>
    public static object[] ObtenerFormaRutaGMR(this Route ruta)
    {
        // Convertimos cada punto o coordenada de un objeto de tipo 'Route' en un 
        // arreglo de coordenadas (ruta) interpretable por un mapa de google-maps-react.
        // Ejemplo: [{lat: 110.4567, lng: 99.5934}, {lat: 110.945712, lng: 98.87120}]
        return ruta.Shape.Select(c => new
        {
            // Utilizamos propiedades 'lat' y 'lng' como lo indica la documentación oficial
            // de la biblioteca JS 'Google Maps React': https://www.npmjs.com/package/google-maps-react
            lat = c.Latitude,
            lng = c.Longitude
        }).ToArray();
    }
}
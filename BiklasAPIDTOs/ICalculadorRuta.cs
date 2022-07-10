using Itinero;
using Itinero.LocalGeo;

namespace Biklas_API_DTOs
{
    public interface ICalculadorRuta
    {
        Route CalcularRutaOptima(Coordinate ini, Coordinate fin);
    }
}

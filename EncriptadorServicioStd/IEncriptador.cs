

namespace EncriptadorServicioStd
{
    public interface IEncriptador
    {
        string Llave { get; }

        string Encriptar(string textoPlano, string llave);
        string Desencriptar(string textoCifr, string llave);
    }
}
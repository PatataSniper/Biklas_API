

namespace Biklas_API_DTOs
{
    public interface IComunicadorCorreo
    {
        void EnviarCorreoRecuperacionContra(string emailDest,
            string contraDest,
            string emailOrig,
            string contraOrig);
    }
}

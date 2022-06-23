

namespace ComunicadorCorreoServicioStd
{
    public interface IComunicadorCorreo
    {
        void EnviarCorreoRecuperacionContra(string emailDest,
            string contraDest,
            string emailOrig,
            string contraOrig);
    }
}

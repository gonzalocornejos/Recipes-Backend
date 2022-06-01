namespace recipes_backend.Integrations.Mailing.Interfaces
{
    public interface IMailing
    {
        Task EnviarCodigoValidacion(string emailDestino, int codigoValidacion);
    }
}

namespace recipes_backend.Services
{
    using recipes_backend.Integrations.Mailing.Interfaces;
    using recipes_backend.Services.Interfaces;
    using System.Threading.Tasks;

    public class MailingService : IMailingService
    {
        // En el caso de haber mas de una integracion con una api de mailing habria que hacer un factory
        // para determinar que integracion utilizar. En este caso no es necesario ya que solo usamos Mailjet.
        private readonly IMailing mailingIntegration;
        public MailingService(IMailing mailing)
        {
            this.mailingIntegration = mailing;
        }

        public async Task EnviarCodigoValidacion(string emailDestino, int codigoValidacion)
        {
            await mailingIntegration.EnviarCodigoValidacion(emailDestino, codigoValidacion);
        }

        public async Task EnviarMaildeActivacion(string emailDestino, string nickName)
        {
            await mailingIntegration.EnviarMaildeValidacion(emailDestino, nickName);
        }
    }
}

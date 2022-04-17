namespace recipes_backend.Integrations.Mailing
{
    using Mailjet.Client;
    using Mailjet.Client.Resources;
    using Newtonsoft.Json.Linq;
    using recipes_backend.Integrations.Mailing.Interfaces;
    using System.Threading.Tasks;

    public class MailjetMailing : IMailing
    {
        private readonly IConfiguration configuration;
        private readonly MailjetClient _client;
        public MailjetMailing(IConfiguration configuration)
        {
            this.configuration = configuration;
            _client = new MailjetClient(this.configuration.GetValue<string>("Mailing:Mailjet:PUBLIC_APIKEY"), 
                this.configuration.GetValue<string>("Mailing:Mailjet:PRIVATE_APIKEY"));
        }

        public async Task EnviarCodigoValidacion(string emailDestino, int codigoValidacion)
        {
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            }.Property(Send.FromEmail, "recetasUADE@gmail.com") // TODO: Crear el mail y asociarlo a Mailjet
             .Property(Send.FromName, "Recetas UADE")
             .Property(Send.Recipients, new JArray
             {
                 new JObject
                 {
                     {"Email", emailDestino }
                 }
             })
             .Property(Send.Subject, "CODIGO DE VALIDACION DE CAMBIO DE CONTRASEÑA - RECETAS UADE")
             .Property(Send.TextPart, "Valide el codigo con la aplicacion para cambiar la contraseña")
             .Property(Send.HtmlPart, $"<h3>Tu codigo de validacion es {codigoValidacion}</h3>"); // TODO: Hacer un html mas lindo

            MailjetResponse response = await _client.PostAsync(request);

            if (!response.IsSuccessStatusCode) {
                throw new Exception("No se ha podido enviar el codigo de validación");
            }
        }
    }
}

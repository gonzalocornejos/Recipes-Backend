namespace recipes_backend.Helpers.Middleware
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    ///    Middleware principal de manejo de excepciones en controladores. Las
    ///    excepciones pueden provenir desde el controlador en sí mismo, o
    ///    desde un nivel inferior dentro de la aplicación.
    /// </summary>
    public sealed class ExceptionHandler
    {

        private readonly RequestDelegate nextMiddleware;

        public ExceptionHandler(RequestDelegate nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }

        /// <summary>
        ///    Procesa el mensaje, atrapando las excepciones generadas.
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await nextMiddleware.Invoke(context);
            }
            catch (Exception exception)
            {
                await SendPayload(context, Envelope.Error(exception.Message));
            }
        }

        private async Task SendPayload<TPayload>(HttpContext context, TPayload payload)
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var result = JsonConvert.SerializeObject(payload, settings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(result);
        }
    }
}

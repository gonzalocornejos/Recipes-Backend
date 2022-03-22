namespace recipes_backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        ///     Intenta iniciar sesion con los parametros
        ///     recibidos.
        /// </summary>
        /// <returns>
        ///     El estado del login, es decir, aceptado o rechazado
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("iniciar-sesion")]
        public Task<IActionResult> IniciarSesion()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Registra al usuario con los datos recibidos.
        /// </summary>
        /// <returns>
        ///     Estado del proceso de registro.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("registrarse")]
        public Task<IActionResult> Registrarse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Valida si los datos enviados en el primer proceso
        ///     de registro son correctos o validos.
        /// </summary>
        /// <returns>
        ///     Validacion correcta o denegada.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("chequear-primer-paso-registro")]
        public Task<IActionResult> ChequearPrimerPasoRegistro()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Envia un email a la dirrecion pasada por parametro.
        /// </summary>
        /// <returns>
        ///     Estado del proceso de finalizacion del envio de email.
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("recuperar-contraseña")]
        public Task<IActionResult> RecuperarContraseña()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Valida si el codigo enviado por parametro es correcto.
        /// </summary>
        /// <returns>
        ///     Validacion correcta o incorrecta.
        /// </returns>
        [HttpPost]
        [Route("recuperar-contraseña")]
        public Task<IActionResult> ChequearCodigoValidacion()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Cambia la contraseña al usuario solicitado
        /// </summary>
        /// <returns>
        ///     Estado del proceso de finalizacion del cambio de contraseña.
        /// </returns>
        [HttpPost]
        [Route("cambiar-contraseña")]
        public Task<IActionResult> CambiarContraseña()
        {
            throw new NotImplementedException();
        }
    }
}

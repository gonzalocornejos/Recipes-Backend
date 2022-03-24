namespace recipes_backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using recipes_backend.Dtos.Usuario.Authentication;
    using recipes_backend.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService; 
        }

        /// <summary>
        ///     Intenta iniciar sesion con los parametros
        ///     recibidos.
        /// </summary>
        /// <returns>
        ///     El estado del login, es decir, aceptado o rechazado
        /// </returns>
        /// <response code="202">Si las credenciales son validas</response>
        /// <response code="401">Si las credenciales son invalidas </response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("iniciar-sesion")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> IniciarSesion([FromBody] LoguearseDTO credenciales)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Registra al usuario con los datos recibidos.
        /// </summary>
        /// <returns>
        ///     Estado del proceso de registro.
        /// </returns>
        /// <response code="202">Si las credenciales son validas para registrar</response>
        /// <response code="400">Si las credenciales son invalidas para registrar</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("registrarse")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> Registrarse([FromBody] RegistroDTO registroData)
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
        /// <response code="200">Si las credenciales son validas para seguir en el proceso de registro</response>
        /// <response code="400">Si las credenciales son invalidas para seguir en el proceso de registro</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("chequear-primer-paso-registro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> ChequearPrimerPasoRegistro([FromBody] PrimerPasoRegistroDTO primerPasoRegistroData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Envia un codigo de validacion al usuario cuyo
        ///     id es pasado por parametro.
        /// </summary>
        /// <returns>
        ///     Estado del proceso de finalizacion del envio de email.
        /// </returns>
        /// <response code="200">Si se ha enviado correctamente el codigo de validacion de cambio de contraseña</response>
        /// <response code="400">Si no se ha podido enviar correctamente el codigo de validacion de cambio de contraseña</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("recuperar-contraseña/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> RecuperarContraseña([FromQuery] int usuarioId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Valida si el codigo enviado por parametro es correcto.
        /// </summary>
        /// <returns>
        ///     Validacion correcta o incorrecta.
        /// </returns>
        /// <response code="200">Si el codigo de validacion es correcto</response>
        /// <response code="400">Si el codigo de validacion es incorrecto</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("recuperar-contraseña")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> ChequearCodigoValidacion([FromBody] RecuperarContraseñaDTO recuperacionData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Cambia la contraseña al usuario solicitado
        /// </summary>
        /// <returns>
        ///     Estado del proceso de finalizacion del cambio de contraseña.
        /// </returns>
        /// <response code="200">Si la contraseña ha podido modificarse correctamente</response>
        /// <response code="400">Si la contraseña no ha podido modificarse correctamente</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPatch]
        [Route("cambiar-contraseña")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> CambiarContraseña([FromBody] CambiarContraseñaDTO cambiarContraseñaData)
        {
            throw new NotImplementedException();
        }
    }
}

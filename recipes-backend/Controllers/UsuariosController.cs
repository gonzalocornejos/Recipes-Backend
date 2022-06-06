namespace recipes_backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using recipes_backend.Dtos.Usuario.Authentication;
    using recipes_backend.Services.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.Net;

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
        ///     Inicia sesion.
        /// </summary>
        /// <returns>
        ///     Autorizacion del usuario.
        /// </returns>
        /// <param name="credenciales">Credenciales para el logueo</param>
        /// <response code="204">Si las credenciales son validas</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="401">Si las credenciales son invalidas para autenticar</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("iniciar-sesion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> IniciarSesion([FromBody] LoguearseDTO credenciales)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _usuarioService.Loguearse(credenciales);
            return NoContent();
        }

        /// <summary>
        ///     Registra al usuario.
        /// </summary>
        /// <returns>
        ///     Estado de finalizacion del proceso de registro.
        /// </returns>
        /// <param name="registroData">Credenciales para registrarse</param>
        /// <response code="204">Si las credenciales son validas para registrar</response>
        /// <response code="400">Si las credenciales son invalidas para registrar</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("registrarse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registrarse([FromBody] RegistroDTO registroData)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _usuarioService.Registrarse(registroData);
            return NoContent();
        }

        /// <summary>
        ///     Valida si los datos enviados en el primer proceso de registro son correctos o validos.
        /// </summary>
        /// <returns>
        ///     Validacion correcta o denegada.
        /// </returns>
        /// <param name="primerPasoRegistroData">Credenciales para el primer paso del registro</param>
        /// <response code="204">Si las credenciales son validas para seguir en el proceso de registro</response>
        /// <response code="400">Si las credenciales son invalidas para seguir en el proceso de registro</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("chequear-primer-paso-registro")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChequearPrimerPasoRegistro([FromBody] PrimerPasoRegistroDTO primerPasoRegistroData)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");
            await _usuarioService.ChequearPrimerPasoRegistro(primerPasoRegistroData);
            return NoContent();
        }

        /// <summary>
        ///     Envia un codigo de validacion via mail al usuario
        /// </summary>
        /// <returns>
        ///     Estado del proceso de finalizacion del envio de email.
        /// </returns>
        /// <param name="usuarioId">Id del usuario que quiere recuperar la contraseña</param>
        /// <response code="200">Si se ha enviado correctamente el codigo de validacion de cambio de contraseña</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="404">Si no se encontro el usuario</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("recuperar-contraseña/{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarContraseña([FromRoute, Required] int usuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _usuarioService.RecuperarContraseña(usuarioId);
            return NoContent();
        }

        /// <summary>
        ///     Valida si el codigo de validacion para recuperar la contraseña es correcto.
        /// </summary>
        /// <returns>
        ///     Validacion correcta o incorrecta.
        /// </returns>
        /// <param name="usuarioId">Id del usuario</param>
        /// <param name="recuperacionData">Codigo de validacion</param>
        /// <response code="204">Si el codigo de validacion es correcto</response>
        /// <response code="400">Si el codigo de validacion es incorrecto</response>
        /// <response code="404">Si no se encontro el usuario</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("recuperar-contraseña/{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ChequearCodigoValidacion([FromRoute, Required] int usuarioId, [FromBody] RecuperarContraseñaDTO recuperacionData)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            return StatusCode((int)HttpStatusCode.NotImplemented);
        }

        /// <summary>
        ///     Cambia la contraseña.
        /// </summary>
        /// <returns>
        ///     Estado del proceso de finalizacion del cambio de contraseña.
        /// </returns>
        /// <param name="usuarioId">Id del usuario</param>
        /// <param name="cambiarContraseñaData">Nueva contraseña</param>
        /// <response code="204">Si la contraseña ha podido modificarse correctamente</response>
        /// <response code="400">Si la contraseña no ha podido modificarse correctamente por algun parametro</response>
        /// <response code="404">Si no se encontro el usuario</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPatch]
        [Route("cambiar-contraseña/{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CambiarContraseña([FromRoute, Required] int usuarioId, [FromBody] CambiarContraseñaDTO cambiarContraseñaData)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            return StatusCode((int)HttpStatusCode.NotImplemented);
        }

        [HttpGet]
        [Route("activar/{userName}")]
        public async Task<IActionResult> ActivarUsuario([FromRoute, Required] string userName)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _usuarioService.ActivarUsuario(userName);
            return NoContent();
        }
    }
}

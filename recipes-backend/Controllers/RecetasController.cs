namespace recipes_backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Services.Interfaces;
    using System.ComponentModel.DataAnnotations;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetaService _recetaService;

        public RecetasController(IRecetaService recetaService)
        {
            _recetaService = recetaService;
        }

        /// <summary>
        ///     Crea la receta.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>       
        /// <param name="userId">Id del usuario que creará de la receta</param>
        /// <param name="recetaDTO">Informacion de la receta a crear</param>
        /// <response code="201">Si la receta pudo ser creada correctamente</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="404">Si alguna entity no fue encontrada</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("{userId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrearReceta([FromRoute, Required] int userId, [FromBody] CrearRecetaDTO recetaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _recetaService.CrearReceta(userId, recetaDTO);
            return StatusCode((int)HttpStatusCode.Created);
        }

        /// <summary>
        ///     Elimina la receta.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>
        /// <param name="usuarioId">Id del usuario que eliminará la receta</param>
        /// <param name="recetaId">Id de la receta a eliminar</param>
        /// <response code="204">Si la receta pudo ser eliminada correctamente</response>        
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="403">Si no pudo eliminarse la receta por alguna autorizacion</response>
        /// <response code="404">Si alguna entity no fue encontrada</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpDelete]
        [Route("{usuarioId}/{recetaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarReceta([FromRoute, Required] int usuarioId, [FromRoute, Required] int recetaId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _recetaService.EliminarReceta(usuarioId, recetaId);
            return NoContent();
        }

        /// <summary>
        ///     Edita la receta.
        /// </summary>
        /// <returns>
        ///     El modelo de la receta editada.
        /// </returns>
        /// <param name="usuarioId">Id del usuario propietario de la receta</param>
        /// <param name="recetaId">Id de la receta a editar</param>
        /// <param name="recetaEditDTO">Datos a cambiar de la receta</param>
        /// <response code="200">Si la receta pudo ser editada correctamente</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="404">Si alguna entity no fue encontrada</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPatch]
        [Route("{usuarioId}/{idReceta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditarReceta([FromRoute, Required] int usuarioId, [FromRoute, Required] int recetaId, [FromBody] EditarRecetaDTO recetaEditDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            var recetaEditada = await _recetaService.EditarReceta(usuarioId, recetaId, recetaEditDTO);
            return Ok(recetaEditada);
        }

        /// <summary>
        ///     Obtiene las recetas.
        /// </summary>
        /// <returns>
        ///     Listado de recetas.
        /// </returns>
        /// <response code="200">Si las recetas pudieron ser buscadas correctamente</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("buscar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerRecetas([FromBody] PagedQuery<RecetaFiltroParametrosDTO> pagedQuery)
        {
            var result = await _recetaService.ObtenerRecetasAsync(pagedQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Obtiene una receta.
        /// </summary>
        /// <returns>
        ///     La infromacion de la receta pedida.
        /// </returns>
        /// <response code="200">Si la receta pudo ser buscada correctamente</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="404">Si no se encontro la receta</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("{recetaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ObtenerReceta([FromRoute, Required] int recetaId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            var receta = await _recetaService.ObtenerRecetaInfoAsync(recetaId);
            return Ok(receta);
        }

        /// <summary>
        ///     Agrega o elimina de favoritos una receta determinada.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>
        /// <response code="204">Si la receta pudo ser agregada o eliminada de favoritos correctamente</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="404">Si no se encontro alguna entity</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPut]
        [Route("favorito/{userId}/{recetaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ManejarFavorito([FromRoute, Required] int userId, [FromRoute, Required] int recetaId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _recetaService.ManejarFavorito(userId, recetaId);
            return NoContent();
        }

        /// <summary>
        ///     Obtiene los filtros disponibles para realizar la busqueda de una receta.
        /// </summary>
        /// <returns>
        ///     Filtros para buscar una receta.
        /// </returns>
        /// <response code="200">Si se pudieron obtener los filtros correctamente</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("filtros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerFiltros()
        {
            var filters = await _recetaService.ObtenerFiltros();
            return Ok(filters);
        }

        /// <summary>
        ///     Valida si una receta es apta para publicar.
        /// </summary>
        /// <returns>
        ///     Estado de la validacion de la receta.
        /// </returns>
        /// <response code="204">Si la receta fue validada correctamente</response>
        /// <response code="400">Si no se enviaron correctamente los parametros requeridos</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("validar/{recetaId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ValidarReceta([FromRoute, Required] int recetaId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Parametros enviados incorrectamente");

            await _recetaService.ValidarReceta(recetaId);           
            return NoContent();
        }
    }
}

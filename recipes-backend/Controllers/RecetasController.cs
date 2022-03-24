namespace recipes_backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Services.Interfaces;

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
        /// <response code="201">Si la receta pudo ser creada correctamente</response>
        /// <response code="400">Si no pudo crearse la receta por algun parametro</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> CrearReceta([FromBody] CrearRecetaDTO recetaDTO)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Elimina la receta cuyo id es pasado por parametro.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>
        /// <response code="200">Si la receta pudo ser eliminada correctamente</response>
        /// <response code="400">Si no pudo eliminarse la receta por algun parametro</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> EliminarReceta([FromQuery] int recetaId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Edita la receta con los parametros recibidos
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso
        /// </returns>
        ///  <response code="200">Si la receta pudo ser editada correctamente</response>
        /// <response code="400">Si no pudo editarse la receta por algun parametro</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> EditarReceta([FromBody] EditarRecetaDTO recetaEditDTO)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Obtiene las recetas teniendo en cuenta los filtros
        ///     pasados por parametro.
        /// </summary>
        /// <returns>
        ///     Listado de recetas.
        /// </returns>
        /// <response code="200">Si las recetas pudieron ser buscadas correctamente</response>
        /// <response code="400">Si no pudo buscarse las recetas por algun parametro</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPost]
        [Route("buscar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerRecetas([FromBody] PagedQuery<RecetaFiltroDTO> pagedQuery)
        {
            var result = await _recetaService.ObtenerRecetasAsync(pagedQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Obtiene una receta cuyo id es pasado por parametro.
        /// </summary>
        /// <returns>
        ///     La infromacion de una receta.
        /// </returns>
        /// <response code="200">Si la receta pudo ser buscadas correctamente</response>
        /// <response code="404">Si no se encontro la receta</response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ObtenerReceta([FromQuery] int recetaId)
        {
            var receta = await _recetaService.ObtenerRecetaAsync(recetaId);
            return Ok(receta);
        }

        /// <summary>
        ///     Agrega o elimina de favoritos una receta determinada.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>
        /// <response code="200">Si la receta pudo ser agregada o eliminada de favoritos correctamente</response>
        /// <response code="400">Si no pudo agregarse o eliminarse la receta a favoritos </response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpPut]
        [Route("favorito/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> ManejarFavorito([FromQuery] int recetaId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Obtiene los filtros disponibles para realizar la busqueda
        ///  de una receta.
        /// </summary>
        /// <returns>
        ///     Filtros de la receta
        /// </returns>
        /// <response code="200">Si se pudieron obtener los filtros correctamente</response>
        /// <response code="404">Si no se encontraron los filtros </response>
        /// <response code="500">En el caso de haber un problema interno en el codigo</response>
        [HttpGet]
        [Route("filtros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<IActionResult> ObtenerFiltros()
        {
            throw new NotImplementedException();
        }
    }
}

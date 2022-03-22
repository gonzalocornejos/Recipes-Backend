using Microsoft.AspNetCore.Mvc;

namespace recipes_backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        /// <summary>
        ///     Obtiene las recetas teniendo en cuenta los filtros
        ///     pasados por parametro.
        /// </summary>
        /// <returns>
        ///     Listado de recetas.
        /// </returns>
        [HttpGet]
        public Task<IActionResult> ObtenerRecetas()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Crea la receta.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>
        [HttpPost]
        public Task<IActionResult> CrearReceta()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Obtiene una receta cuyo id es pasado por parametro.
        /// </summary>
        /// <returns>
        ///     La infromacion de una receta.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public Task<IActionResult> ObtenerReceta()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Agrega o elimina de favoritos una receta determinada.
        /// </summary>
        /// <returns>
        ///     El estado de finalizacion del proceso.
        /// </returns>
        [HttpPost]
        [Route("favorito/{idReceta}")]
        public Task<IActionResult> ManejarFavorito()
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
        [HttpGet]
        [Route("filtros")]
        public Task<IActionResult> ObtenerFiltros()
        {
            throw new NotImplementedException();
        }
    }
}

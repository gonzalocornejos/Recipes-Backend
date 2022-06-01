namespace recipes_backend.Services.Interfaces
{
    using CSharpFunctionalExtensions;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;

    public interface IRecetaService
    {
        /// <summary>
        ///     Obtiene de manera sincronica las recetas con los
        ///     parametros recibidos.
        /// </summary>
        /// <param name="pagedQuery"></param>
        /// <returns>
        ///     Listado de recetas.
        /// </returns>
        Task<PagedQueryResult<RecetaResultadoDTO>> ObtenerRecetasAsync(PagedQuery<RecetaFiltroParametrosDTO> pagedQuery);

        /// <summary>
        ///     Obtiene de manera sincronica una receta en especifico.
        /// </summary>
        /// <param name="recetaId"></param>
        /// <returns>
        ///     La receta cuyo parametro es pasado por parametro.
        /// </returns>
        Task<RecetaInfoDTO> ObtenerRecetaInfoAsync(int recetaId);

        /// <summary>
        ///     Busca al usuario para luego darle la responsabilidad
        ///     de crear su receta.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recetaDTO"></param>
        /// <returns>
        ///     Resultado Success o Fail del proceso
        /// </returns>
        Task CrearReceta(int userId, CrearRecetaDTO recetaDTO);

        Task<RecetaInfoDTO> EditarReceta(int usuarioId, int recetaId, EditarRecetaDTO recetaEditDTO);

        /// <summary>
        ///     Busca al usuario para luego darle la responsabilidad 
        ///     de eliminar su receta.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recetaId"></param>
        /// <returns>
        ///     Resultado Success o Fail del proceso
        /// </returns>
        Task EliminarReceta(int userId, int recetaId);

        Task ManejarFavorito(string nickName, int recetaId);

        Task<RecetaFiltroDTO> ObtenerFiltros();

        Task<bool> ValidarReceta(int recetaId);
    }
}

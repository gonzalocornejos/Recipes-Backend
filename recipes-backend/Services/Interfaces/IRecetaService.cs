namespace recipes_backend.Services.Interfaces
{
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
        Task<PagedQueryResult<RecetaResultadoDTO>> ObtenerRecetasAsync(PagedQuery<RecetaFiltroDTO> pagedQuery);

        /// <summary>
        ///     Obtiene de manera sincronica una receta en especifico.
        /// </summary>
        /// <param name="recetaId"></param>
        /// <returns>
        ///     La receta cuyo parametro es pasado por parametro.
        /// </returns>
        Task<RecetaInfoDTO> ObtenerRecetaAsync(int recetaId);
    }
}

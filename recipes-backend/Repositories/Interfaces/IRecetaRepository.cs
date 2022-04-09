namespace recipes_backend.Repositories.Interfaces
{
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Models.Domain;

    public interface IRecetaRepository
    {
        /// <summary>
        ///     Busca y pagina en la base de datos las recetas, 
        ///     teniendo en cuenta los parametros recibidos.
        /// </summary>
        /// <param name="pagedQuery"></param>
        /// <returns>
        ///     Listado de recetas con su respectivo paginado
        /// </returns>
        Task<PagedQueryResult<RecetaResultadoDTO>> BuscarRecetas(PagedQuery<RecetaFiltroParametrosDTO> pagedQuery);

        /// <summary>
        ///     Busca en la base de datos una receta individual.
        /// </summary>
        /// <param name="recetaId"></param>
        /// <returns>
        ///     Receta individual.
        /// </returns>
        Task<Receta> BuscarReceta(int recetaId);
    }
}

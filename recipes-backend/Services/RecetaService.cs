namespace recipes_backend.Services
{
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Repositories.Interfaces;
    using recipes_backend.Services.Interfaces;
    using System.Threading.Tasks;

    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _recetaRepository;

        public RecetaService(IRecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }

        public async Task<PagedQueryResult<RecetaResultadoDTO>> ObtenerRecetasAsync(PagedQuery<RecetaFiltroDTO> pagedQuery)
        {
            return await _recetaRepository.BuscarRecetas(pagedQuery);
        }

        public async Task<RecetaInfoDTO> ObtenerRecetaAsync(int recetaId)
        {
            return await _recetaRepository.BuscarReceta(recetaId);
        }
    }
}

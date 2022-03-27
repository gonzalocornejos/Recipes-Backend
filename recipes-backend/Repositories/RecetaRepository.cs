namespace recipes_backend.Repositories
{
    using AutoMapper;
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Repositories.Interfaces;
    using System.Threading.Tasks;
    using static recipes_backend.Helpers.Query.Type;

    public class RecetaRepository : IRecetaRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public RecetaRepository(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PagedQueryResult<RecetaResultadoDTO>> BuscarRecetas(PagedQuery<RecetaFiltroDTO> pagedQuery)
        {
            var query = $@"FROM Recetas R
                           WHERE 1 = 1 
                           {Has(pagedQuery.Filter.Nombre, "AND R.Nombre = @Nombre", "")}
                           ORDER BY R.{pagedQuery.SortField} {pagedQuery.SortOrder}
                           OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                Nombre = pagedQuery.Filter.Nombre,
                Offset = pagedQuery.PageSize * (pagedQuery.PageNumber - 1),
                PageSize = pagedQuery.PageSize
            };

            var result = _dbContext.Database.GetDbConnection()
                            .Query<RecetaResultadoDTO>($"SELECT * {query}", parameters)
                            .ToList();

            var totalCount = _dbContext.Database.GetDbConnection()
                            .Query<int>($"SELECT COUNT(1) {query}", parameters)
                            .FirstOrDefault();

            return new PagedQueryResult<RecetaResultadoDTO>
            {
                Items = result,
                TotalCount = totalCount
            };
        }

        public async Task<RecetaInfoDTO> BuscarReceta(int recetaId)
        {
            var receta = await _dbContext.Receta
                .Where(r => r.Id == recetaId)
                .FirstOrDefaultAsync();

            return _mapper.Map<RecetaInfoDTO>(receta);
        }
    }
}

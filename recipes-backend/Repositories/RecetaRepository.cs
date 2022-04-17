namespace recipes_backend.Repositories
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Foto;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Models.Domain;
    using recipes_backend.Repositories.Interfaces;
    using System.Threading.Tasks;
    using static recipes_backend.Helpers.Query.Type;

    public class RecetaRepository : IRecetaRepository
    {
        private readonly DataContext _dbContext;

        public RecetaRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedQueryResult<RecetaResultadoDTO>> BuscarRecetas(PagedQuery<RecetaFiltroParametrosDTO> pagedQuery)
        {
            var query = $@"WITH Recetas (Id, Nombre, Descripcion, Porciones, FotoFinal) AS (
                                    SELECT R.Id, R.Nombre, R.Descripcion, R.Porciones, R.Foto
	                                FROM Receta R
		                                INNER JOIN Usuario U ON U.Id = R.UsuarioId
		                                INNER JOIN TipoPlato TP ON TP.Id = R.TipoPlatoId
		                                INNER JOIN Utilizados UT ON UT.RecetaId = R.Id
		                                INNER JOIN Ingrediente I ON I.Id = UT.IngredienteId		
	                                WHERE 1 = 1
		                                {Has(pagedQuery.Filter.Nombre, "AND R.Nombre LIKE '%' + @Nombre + '%'", "")}
                                        {Has(pagedQuery.Filter.TipoPlatos, "AND TP.Descripcion IN (@TipoPlatos)", "")}
                                        {Has(pagedQuery.Filter.Ingredientes, "AND I.Nombre IN (@Ingredientes)", "")}
                                        {Has(pagedQuery.Filter.IngredientesExcluidos, "AND I.Nombre NOT IN (@IngredientesExcluidos)", "")}
                                        {Has(pagedQuery.Filter.NickName, "AND U.NickName LIKE '%' + @Nickname + '%'", "")}
	                                ORDER BY R.{pagedQuery.SortField} {pagedQuery.SortOrder}
	                                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
                                ), ValoracionReceta (RecetaId, ValoracionPromedio) AS (
	                                SELECT R.Id, SUM(C.Puntaje) * 1.0 / COUNT(1)
	                                FROM Recetas R
		                                INNER JOIN Calificacion C ON C.RecetaId = R.Id	
	                                GROUP BY R.Id
                                )
                                SELECT R.Id, R.Nombre, R.Descripcion, R.Porciones, VR.ValoracionPromedio,
                                    FF.FotoFinalId, FF.Url, FF.Extension,                                  
                                FROM Recetas R
                                    INNER JOIN ValoracionReceta VR ON VR.RecetaId = R.Id
                                    INNER JOIN FotosFinales FF ON FF.RecetaId = R.Id
                                ORDER BY R.{pagedQuery.SortField} {pagedQuery.SortOrder}, P.NroPaso";

            var parameters = new
            {
                Nombre = pagedQuery.Filter.Nombre,
                TipoPlatos = pagedQuery.Filter.TipoPlatos,
                Ingredientes = pagedQuery.Filter.Ingredientes,
                IngredientesExcludios = pagedQuery.Filter.IngredientesExcluidos,
                NickName = pagedQuery.Filter.NickName,
                Offset = pagedQuery.PageSize * (pagedQuery.PageNumber - 1),
                PageSize = pagedQuery.PageSize
            };

            // Diccionario para el Query Multi-Mapping (One to Many) de Dapper
            var queryDictionary = new Dictionary<int, RecetaResultadoDTO>();

            var result = _dbContext.Database.GetDbConnection()
                           .Query<RecetaResultadoDTO, FotoDTO, RecetaResultadoDTO >(query,
                                    (resultQuery, fotoFinal) => {
                                        RecetaResultadoDTO entry;
                                        if (!queryDictionary.TryGetValue(resultQuery.Id, out entry))
                                            queryDictionary.Add(entry.Id, entry = resultQuery);
                                                                                                                        
                                        if (fotoFinal.FotoFinalId != 0)
                                            entry.FotosFinales.Add(fotoFinal);

                                        return entry;
                                    },
                                    parameters,
                                    splitOn:"FotoFinalId")
                            .Distinct()
                            .ToList();

            return new PagedQueryResult<RecetaResultadoDTO>
            {
                Items = result,
            };
        }

        public async Task<Receta> BuscarReceta(int recetaId)
        {
            return await _dbContext.Receta
                .Where(r => r.Id == recetaId)
                .FirstOrDefaultAsync();
        }
    }
}

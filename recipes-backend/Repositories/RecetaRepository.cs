namespace recipes_backend.Repositories
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
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
            var query = $@"WITH Recetas (Id, Nombre, Descripcion, Porciones, FotoFinal, Nickname, EsFavorito) AS (
                                    SELECT R.Id AS RecipeId, R.Nombre, R.Descripcion, R.Porciones, R.Foto, U.NickName, IIF(F.Id IS NULL, 0, 1)
	                                FROM Receta R -- Cambiar estos LEFT por INNER despues de tener el modulo completo
		                                LEFT JOIN Usuario U ON U.Id = R.UsuarioId
		                                LEFT JOIN RecetaTipoPlato RTP ON RTP.RecetaId = R.Id
		                                LEFT JOIN TipoPlato TP ON TP.Id = RTP.TipoPlatoId
		                                LEFT JOIN Utilizados UT ON UT.RecetaId = R.Id
		                                LEFT JOIN Ingrediente I ON I.Id = UT.IngredienteId
		                                INNER JOIN Usuario UL ON UL.NickName = @UsuarioLogueado
                                        LEFT JOIN Favorita F ON F.UsuarioId = UL.Id AND F.RecetaId = R.Id
	                                WHERE 1 = 1
                                        {(pagedQuery.Filter.SoloPropias ? "AND U.NickName IN (@UsuarioLogueado)" : "AND U.NickName NOT IN (@UsuarioLogueado)")}
		                                {Has(pagedQuery.Filter.Nombre, "AND R.Nombre LIKE '%' + @Nombre + '%'", "")}
                                        {Has(pagedQuery.Filter.TipoPlatos, "AND TP.Descripcion IN @TipoPlatos", "")}
                                        {Has(pagedQuery.Filter.Ingredientes, "AND I.Nombre IN @Ingredientes", "")}
                                        {Has(pagedQuery.Filter.IngredientesExcluidos, @"AND NOT EXISTS (SELECT * 
                                                                                                        FROM Utilizados U2
                                                                                                            INNER JOIN Ingrediente I2 ON I2.Id = U2.IngredienteId
                                                                                                        WHERE U2.RecetaId = R.Id
                                                                                                            AND I2.Nombre IN @IngredientesExcluidos)", "")}
                                        {Has(pagedQuery.Filter.NickName, "AND U.NickName LIKE '%' + @Nickname + '%'", "")}    
                                        {(pagedQuery.Filter.SoloFavoritos ? "AND F.Id IS NOT NULL" : "")}
                                    GROUP BY R.Id, R.Nombre, R.Descripcion, R.Porciones, R.Foto, U.NickName, F.Id
                                    ORDER BY {pagedQuery.SortField} {pagedQuery.SortOrder}
	                                OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
                                ), ValoracionReceta (RecetaId, ValoracionPromedio) AS (
	                                SELECT R.Id, SUM(C.Puntaje) * 1.0 / COUNT(1)
	                                FROM Recetas R
		                                INNER JOIN Calificacion C ON C.RecetaId = R.Id	
	                                GROUP BY R.Id
                                )
                                SELECT R.Id AS RecipeId, R.Nombre, R.Descripcion, R.Porciones, R.Nickname,
                                    CAST(ISNULL(VR.ValoracionPromedio, 0) AS DECIMAL(7,1)) AS ValoracionPromedio, R.FotoFinal, R.EsFavorito                                 
                                FROM Recetas R
                                    LEFT JOIN ValoracionReceta VR ON VR.RecetaId = R.Id
                                ORDER BY {pagedQuery.SortField} {pagedQuery.SortOrder}";

            var parameters = new
            {
                UsuarioLogueado = pagedQuery.Filter.UsuarioLogueado,
                Nombre = pagedQuery.Filter.Nombre,
                TipoPlatos = pagedQuery.Filter.TipoPlatos,
                Ingredientes = pagedQuery.Filter.Ingredientes,
                IngredientesExcluidos = pagedQuery.Filter.IngredientesExcluidos,
                NickName = pagedQuery.Filter.NickName,
                Offset = pagedQuery.PageSize * (pagedQuery.PageNumber - 1),
                PageSize = pagedQuery.PageSize
            };

            var result = _dbContext.Database.GetDbConnection()
                           .Query<RecetaResultadoDTO>(query,parameters)
                           .ToList();

            return new PagedQueryResult<RecetaResultadoDTO>
            {
                Items = result,
            };
        }

        public async Task<Receta> BuscarReceta(int recetaId)
        {
            return await _dbContext.Receta
                .Include(r => r.Usuario)
                .Include(r => r.TiposPlato)
                    .ThenInclude(tp => tp.TipoPlato)
                .Include(r => r.Calificaciones)
                .Include(r => r.Ingredientes)
                    .ThenInclude(i => i.Unidad)
                .Include(r => r.Ingredientes)
                    .ThenInclude(i => i.Ingrediente)
                .Include(r => r.Pasos)
                    .ThenInclude(p => p.Multimedias)
                .Where(r => r.Id == recetaId)
                .FirstOrDefaultAsync();
        }

        public async Task<Receta> BuscarRecetaByNameAndUsuario(string userName, string recetaName)
        {
            return await _dbContext.Receta
               .Include(r => r.Usuario)
               .Include(r => r.TiposPlato)
                   .ThenInclude(tp => tp.TipoPlato)
               .Include(r => r.Calificaciones)
               .Include(r => r.Ingredientes)
                   .ThenInclude(i => i.Unidad)
               .Include(r => r.Ingredientes)
                   .ThenInclude(i => i.Ingrediente)
               .Include(r => r.Pasos)
                   .ThenInclude(p => p.Multimedias)
               .Where(r => r.Nombre == recetaName && r.Usuario.NickName == userName)
               .FirstOrDefaultAsync();
        }

        public async Task<Calificacion> ObtenerCalificacionRecetaPorUsuario(int recetaId, string userName)
        {
            return await _dbContext.Calificacion
                .Include(c => c.Receta)
                .Include(c => c.Usuario)
                .Where(c => c.Usuario.NickName == userName && c.Receta.Id == recetaId)
                .FirstOrDefaultAsync();
        }

        public async Task<Receta> BuscarReceta(int recetaId, string userName)
        {
            return await _dbContext.Receta
               .Include(r => r.Usuario)
               .Include(r => r.TiposPlato)
                   .ThenInclude(tp => tp.TipoPlato)
               .Include(r => r.Calificaciones)
               .Include(r => r.Ingredientes)
                   .ThenInclude(i => i.Unidad)
               .Include(r => r.Ingredientes)
                   .ThenInclude(i => i.Ingrediente)
               .Include(r => r.Pasos)
                   .ThenInclude(p => p.Multimedias)
               .Where(r => r.Id == recetaId && r.Usuario.NickName == userName)
               .FirstOrDefaultAsync();
        }
    }
}

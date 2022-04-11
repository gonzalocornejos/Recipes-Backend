namespace recipes_backend.Repositories
{
    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Foto;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Multimedia;
    using recipes_backend.Dtos.Paso;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Models.Domain;
    using recipes_backend.Models.ORM;
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
                                ), FotosFinales (RecetaId, FotoFinalId, Url, Extension) AS (
	                                SELECT R.Id, F.Id, F.UrlFoto, F.Extension 
	                                FROM Recetas R
		                                INNER JOIN Foto F ON F.RecetaId = R.Id
                                ), Ingredientes (RecetaId, IngredienteId, Ingrediente, Cantidad) AS (
	                                SELECT R.Id, I.Id, I.Nombre, UT.Cantidad 
	                                FROM Recetas R
		                                INNER JOIN Utilizados UT ON UT.RecetaId = R.Id
		                                INNER JOIN Ingrediente I ON I.Id = UT.IngredienteId		
                                ), Pasos (RecetaId, PasoId, NroPaso, Descripcion) AS (
	                                SELECT R.Id, P.Id, P.NroPaso, P.Texto
	                                FROM Recetas R
		                                INNER JOIN Paso P ON P.RecetaId = R.Id	
                                ), MultimediasPaso (PasoId, MultimediaPasoId, TipoContenido, Extension, UrlContenido) AS (
	                                SELECT P.PasoId, M.Id, M.TipoContenido, M.Extension, M.UrlContenido
	                                FROM Pasos P
		                                INNER JOIN Multimedia M ON M.PasoId = P.PasoId
                                )
                                SELECT R.Id, R.Nombre, R.Descripcion, R.Porciones, VR.ValoracionPromedio,
                                    FF.FotoFinalId, FF.Url, FF.Extension,
                                    I.IngredienteId, I.Ingrediente, I.Cantidad,
                                    P.PasoId, P.NroPaso, P.Descripcion,
                                    MP.MultimediaPasoId, MP.TipoContenido, MP.Extension, MP.UrlContenido
                                FROM Recetas R
                                    INNER JOIN ValoracionReceta VR ON VR.RecetaId = R.Id
                                    INNER JOIN FotosFinales FF ON FF.RecetaId = R.Id
                                    INNER JOIN Ingredientes I ON I.RecetaId = R.Id
                                    INNER JOIN Pasos P ON P.RecetaId = R.Id
                                    INNER JOIN MultimediasPaso MP ON MP.PasoId = P.PasoId
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
                           .Query<RecetaResultadoDTO, FotoDTO, IngredienteDTO, PasoDTO, MultimediaDTO, RecetaResultadoDTO >(query,
                                    (resultQuery, fotoFinal, ingrediente, paso, multimedia) => {
                                        RecetaResultadoDTO entry;
                                        if (!queryDictionary.TryGetValue(resultQuery.Id, out entry))
                                            queryDictionary.Add(entry.Id, entry = resultQuery);
                                       
                                        if (ingrediente.IngredienteId != 0)                                       
                                            entry.Ingredientes.Add(ingrediente);                                           
                                        
                                        if (fotoFinal.FotoFinalId != 0)
                                            entry.FotosFinales.Add(fotoFinal);

                                        if(paso.PasoId != 0){
                                            entry.Pasos.Add(paso);
                                            if (multimedia.MultimediaPasoId != 0)
                                                entry.Pasos.Where(p => p == paso).First().Multimedias.Add(multimedia);                                           
                                        }
                                        return entry;
                                    },
                                    parameters,
                                    splitOn:"FotoFinalId,IngredienteId,PasoId,MultimediaPasoId")
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

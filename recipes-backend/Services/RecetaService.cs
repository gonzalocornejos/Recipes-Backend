namespace recipes_backend.Services
{
    using AutoMapper;
    using CSharpFunctionalExtensions;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Repositories.Interfaces;
    using recipes_backend.Services.Interfaces;
    using System.Threading.Tasks;

    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITipoPlatoRepository _tipoPlatoRepository;
        private readonly IIngredienteRepository _ingredienteRepository;

        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;

        public RecetaService(IRecetaRepository recetaRepository, 
            IUsuarioRepository usuarioRepository, 
            ITipoPlatoRepository tipoPlatoRepository, 
            IIngredienteRepository ingredienteRepository,
            IMapper mapper,
            DataContext dbContext)
        {
            _recetaRepository = recetaRepository;
            _usuarioRepository = usuarioRepository;
            _tipoPlatoRepository = tipoPlatoRepository;
            _ingredienteRepository = ingredienteRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagedQueryResult<RecetaResultadoDTO>> ObtenerRecetasAsync(PagedQuery<RecetaFiltroParametrosDTO> pagedQuery)
        {
            return await _recetaRepository.BuscarRecetas(pagedQuery);
        }

        public async Task<RecetaInfoDTO> ObtenerRecetaInfoAsync(int recetaId)
        {
            var receta = await _recetaRepository.BuscarReceta(recetaId);
            return _mapper.Map<RecetaInfoDTO>(receta);
        }

        public async Task<Result> CrearReceta(int userId, CrearRecetaDTO recetaDTO)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuario(userId);
                if (usuario == null)
                    throw new Exception("Usuario Invalido");

                var tipoPlato = await _tipoPlatoRepository.BuscarTipoPlato(recetaDTO.TipoPlatoId);
                if (tipoPlato == null)
                    throw new Exception("Tipo de plato invalido");

                usuario.CrearReceta(recetaDTO.Nombre, recetaDTO.Descripcion, recetaDTO.Foto, 
                    recetaDTO.Porciones, recetaDTO.CantidadPersonas, tipoPlato);
                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> EditarReceta(EditarRecetaDTO recetaEditDTO)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuario(recetaEditDTO.UsuarioId);
                if (usuario == null)
                    throw new Exception("Usuario Invalido");

                var receta = await _recetaRepository.BuscarReceta(recetaEditDTO.RecetaEditada.Id);
                if (receta == null)
                    throw new Exception("Receta Invalida");

                //...
                // Logica de editar receta
                // ...

                await _dbContext.SaveChangesAsync();
                return Result.Success(_mapper.Map<RecetaInfoDTO>(receta));
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> EliminarReceta(int userId, int recetaId)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuario(userId);
                if (usuario == null)
                    throw new Exception("Usuario Invalido");

                var receta = await _recetaRepository.BuscarReceta(recetaId);
                if (receta == null)
                    throw new Exception("Receta Invalida");

                usuario.EliminarReceta(receta);
                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<Result> ManejarFavorito(int userId, int recetaId)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscarUsuario(userId);
                if (usuario == null)
                    throw new Exception("Usuario Invalido");

                var receta = await _recetaRepository.BuscarReceta(recetaId);
                if (receta == null)
                    throw new Exception("Receta Invalida");

                usuario.ToggleFavorito(receta);
                await _dbContext.SaveChangesAsync();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }

        public async Task<RecetaFiltroDTO> ObtenerFiltros()
        {
            var categorias = await _tipoPlatoRepository.ObtenerTipoPlatos();
            var ingredientes = await _ingredienteRepository.ObtenerIngredientes();
            return new RecetaFiltroDTO
            {
                Categorias = _mapper.Map<List<CategoriaDTO>>(categorias),
                Ingredientes = _mapper.Map<List<IngredienteDTO>>(ingredientes)
            };
        }

        public async Task<Result> ValidarReceta(int recetaId)
        {
            try
            {
                var receta = await _recetaRepository.BuscarReceta(recetaId);
                if (receta == null)
                    throw new Exception("Receta Invalida");

                // ...
                // Logica de validacion
                // ...

                return Result.Success();
            }
            catch(Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

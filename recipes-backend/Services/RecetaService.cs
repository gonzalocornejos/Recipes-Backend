namespace recipes_backend.Services
{
    using AutoMapper;
    using CSharpFunctionalExtensions;
    using recipes_backend.Data;
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
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;

        public RecetaService(IRecetaRepository recetaRepository, IMapper mapper, IUsuarioRepository usuarioRepository, 
            ITipoPlatoRepository tipoPlatoRepository, DataContext dbContext)
        {
            _dbContext = dbContext;
            _recetaRepository = recetaRepository;
            _usuarioRepository = usuarioRepository;
            _tipoPlatoRepository = tipoPlatoRepository;
            _mapper = mapper;
        }

        public async Task<PagedQueryResult<RecetaResultadoDTO>> ObtenerRecetasAsync(PagedQuery<RecetaFiltroDTO> pagedQuery)
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

                _dbContext.SaveChanges();

                return Result.Success();
            }
            catch(Exception ex)
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

                _dbContext.SaveChanges();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}

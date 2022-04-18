namespace recipes_backend.Services
{
    using AutoMapper;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Exceptions;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Repositories.Interfaces;
    using recipes_backend.Services.Interfaces;
    using System.Net;
    using System.Threading.Tasks;

    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITipoPlatoRepository _tipoPlatoRepository;
        private readonly IIngredienteRepository _ingredienteRepository;

        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public RecetaService(IRecetaRepository recetaRepository, 
            IUsuarioRepository usuarioRepository, 
            ITipoPlatoRepository tipoPlatoRepository, 
            IIngredienteRepository ingredienteRepository,
            IMapper mapper,
            IGenericRepository genericRepository)
        {
            _recetaRepository = recetaRepository;
            _usuarioRepository = usuarioRepository;
            _tipoPlatoRepository = tipoPlatoRepository;
            _ingredienteRepository = ingredienteRepository;
            _mapper = mapper;
            _genericRepository = genericRepository;
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

        public async Task CrearReceta(int userId, CrearRecetaDTO recetaDTO)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(userId);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var tipoPlato = await _tipoPlatoRepository.BuscarTipoPlato(recetaDTO.TipoPlatoId);
            if (tipoPlato == null)
                throw new AppException("Tipo de plato invalido", HttpStatusCode.NotFound);

            usuario.CrearReceta(recetaDTO.Nombre, recetaDTO.Descripcion, recetaDTO.Foto, 
                recetaDTO.Porciones, recetaDTO.CantidadPersonas, tipoPlato);
            await _genericRepository.GuardarCambiosAsync();
        }

        public async Task<RecetaInfoDTO> EditarReceta(int usuarioId, int recetaId, EditarRecetaDTO recetaEditDTO)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(usuarioId);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var receta = await _recetaRepository.BuscarReceta(recetaId);
            if (receta == null)
                throw new AppException("Receta Invalida", HttpStatusCode.NotFound);

            if (receta.Usuario != usuario)
                throw new AppException("No autorizado a eliminar la receta", HttpStatusCode.Forbidden);

            //...
            // Logica de editar receta
            // ...

            await _genericRepository.GuardarCambiosAsync();
            return _mapper.Map<RecetaInfoDTO>(receta);
        }

        public async Task EliminarReceta(int userId, int recetaId)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(userId);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var receta = await _recetaRepository.BuscarReceta(recetaId);
            if (receta == null)
                throw new AppException("Receta Invalida", HttpStatusCode.NotFound);

            if (receta.Usuario != usuario)
                throw new AppException("No autorizado a eliminar la receta", HttpStatusCode.Forbidden);

            usuario.EliminarReceta(receta);
            await _genericRepository.GuardarCambiosAsync();
        }

        public async Task ManejarFavorito(int userId, int recetaId)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(userId);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var receta = await _recetaRepository.BuscarReceta(recetaId);
            if (receta == null)
                throw new AppException("Receta Invalida", HttpStatusCode.NotFound);

            usuario.ToggleFavorito(receta);
            await _genericRepository.GuardarCambiosAsync();
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

        public async Task<bool> ValidarReceta(int recetaId)
        {
            var receta = await _recetaRepository.BuscarReceta(recetaId);
            if (receta == null)
                throw new AppException("Receta Invalida", HttpStatusCode.NotFound);

            // ...
            // Logica de validacion
            // ...

            return true;          
        }
    }
}

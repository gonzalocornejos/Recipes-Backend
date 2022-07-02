namespace recipes_backend.Services
{
    using AutoMapper;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Dtos.Receta.Query;
    using recipes_backend.Dtos.Unidad;
    using recipes_backend.Dtos.Utilizados;
    using recipes_backend.Exceptions;
    using recipes_backend.Helpers.Query;
    using recipes_backend.Models.Domain;
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
        private readonly IUnidadRepository _unidadRepository;

        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;

        public RecetaService(IRecetaRepository recetaRepository, 
            IUsuarioRepository usuarioRepository, 
            ITipoPlatoRepository tipoPlatoRepository, 
            IIngredienteRepository ingredienteRepository,
            IMapper mapper,
            IGenericRepository genericRepository,
            IUnidadRepository unidadRepository)
        {
            _recetaRepository = recetaRepository;
            _usuarioRepository = usuarioRepository;
            _tipoPlatoRepository = tipoPlatoRepository;
            _ingredienteRepository = ingredienteRepository;
            _mapper = mapper;
            _genericRepository = genericRepository;
            _unidadRepository = unidadRepository;
        }

        public async Task<PagedQueryResult<RecetaResultadoDTO>> ObtenerRecetasAsync(PagedQuery<RecetaFiltroParametrosDTO> pagedQuery)
        {
            return await _recetaRepository.BuscarRecetas(pagedQuery);
        }

        public async Task<RecetaInfoDTO> ObtenerRecetaInfoAsync(int recetaId)
        {
            var receta = await _recetaRepository.BuscarReceta(recetaId);
            if (receta == null)
                throw new AppException("Receta Invalida", HttpStatusCode.NotFound);

            return new RecetaInfoDTO(receta);
        }

        public async Task CrearReceta(string userName, CrearRecetaDTO recetaDTO)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(userName);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var tiposPlato = new List<TipoPlato>();
            foreach (var categoria in recetaDTO.Categorias)
            {
                tiposPlato.Add( await _tipoPlatoRepository.BuscarTipoPlato(categoria.Categoria.Id));
            }
            if (tiposPlato == null)
                throw new AppException("Tipo de plato invalido", HttpStatusCode.NotFound);

            var utilizados = new List<UtilizadoDTO>();
            foreach (var ingrediente in recetaDTO.Ingredientes)
            {
                var newIngrediente = await _ingredienteRepository.ObtenerIngredienteByNombre(ingrediente.Nombre);
                if (newIngrediente == null)
                {
                    newIngrediente = new Ingrediente(ingrediente.Nombre);
                }

                var unidad = await _unidadRepository.ObtenerUnidadById(ingrediente.Unidad);

                if (unidad == null)
                    throw new AppException("Unidad invalida", HttpStatusCode.NotFound);

                utilizados.Add(new UtilizadoDTO(newIngrediente, Int32.Parse(ingrediente.Cantidad), unidad, ingrediente.Descripcion));

            }

            usuario.CrearReceta(recetaDTO.Nombre, recetaDTO.Descripcion, recetaDTO.Imagen,
                recetaDTO.Porciones, recetaDTO.Porciones, tiposPlato, recetaDTO.Pasos, utilizados);
            await _genericRepository.GuardarCambiosAsync();
        }

        public async Task<RecetaInfoDTO> EditarReceta(string usuarioName, CrearRecetaDTO recetaEditDTO)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(usuarioName);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var receta = await _recetaRepository.BuscarRecetaByNameAndUsuario(usuario, recetaEditDTO.Nombre);
            if (receta == null)
                throw new AppException("Receta Invalida", HttpStatusCode.NotFound);

            if (receta.Usuario != usuario)
                throw new AppException("No autorizado a eliminar la receta", HttpStatusCode.Forbidden);

            var tiposPlato = new List<TipoPlato>();
            foreach (var categoria in recetaEditDTO.Categorias)
            {
                tiposPlato.Add(await _tipoPlatoRepository.BuscarTipoPlato(categoria.Categoria.Id));
            }
            if (tiposPlato == null)
                throw new AppException("Tipo de plato invalido", HttpStatusCode.NotFound);

            var utilizados = new List<UtilizadoDTO>();
            foreach (var ingrediente in recetaEditDTO.Ingredientes)
            {
                var newIngrediente = await _ingredienteRepository.ObtenerIngredienteByNombre(ingrediente.Nombre);
                if (newIngrediente == null)
                {
                    newIngrediente = new Ingrediente(ingrediente.Nombre);
                }

                var unidad = await _unidadRepository.ObtenerUnidadById(ingrediente.Unidad);

                if (unidad == null)
                    throw new AppException("Unidad invalida", HttpStatusCode.NotFound);

                utilizados.Add(new UtilizadoDTO(newIngrediente, Int32.Parse(ingrediente.Cantidad), unidad, ingrediente.Descripcion));

            }

            receta.EditarReceta(usuario, recetaEditDTO.Nombre, recetaEditDTO.Descripcion, recetaEditDTO.Imagen, recetaEditDTO.Porciones, recetaEditDTO.Porciones, recetaEditDTO.Pasos, tiposPlato, utilizados);

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

        public async Task ManejarFavorito(string nickName, int recetaId)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(nickName);
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
            var unidades = await _unidadRepository.ObtenerUnidades();
            return new RecetaFiltroDTO
            {
                Categorias = _mapper.Map<List<CategoriaDTO>>(categorias),
                Ingredientes = _mapper.Map<List<IngredienteDTO>>(ingredientes),
                Unidades = _mapper.Map<List<UnidadDTO>>(unidades)
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

        public async Task<bool> VerificarNombreRecetaExsitente(string nickName, string nombreReceta)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(nickName);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var receta = await _recetaRepository.BuscarRecetaByNameAndUsuario(usuario, nombreReceta);
            if (receta == null) 
                return false;
            return true;
        }

        public async Task<RecetaInfoDTO> ObtenerRecetaInfoByNombre(string nickName, string nombreReceta)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(nickName);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            var receta = await _recetaRepository.BuscarRecetaByNameAndUsuario(usuario, nombreReceta);

            return new RecetaInfoDTO(receta);
        }

        public async Task SobreescribirReceta(string userName, CrearRecetaDTO recetaDTO)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(userName);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);
            var receta = await _recetaRepository.BuscarRecetaByNameAndUsuario(usuario, recetaDTO.Nombre);
            await EliminarReceta(usuario.Id, receta.Id);
            await CrearReceta(userName, recetaDTO);
        }

    }
}

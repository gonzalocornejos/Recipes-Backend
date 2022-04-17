namespace recipes_backend.Services
{
    using recipes_backend.Data;
    using recipes_backend.Exceptions;
    using recipes_backend.Repositories.Interfaces;
    using recipes_backend.Services.Interfaces;
    using System.Net;
    using System.Threading.Tasks;

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMailingService _mailingService;

        private readonly DataContext _dbContext;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMailingService mailingService, DataContext dbContext)
        {
            _usuarioRepository = usuarioRepository;
            _mailingService = mailingService;
            _dbContext = dbContext;
        }

        public async Task RecuperarContraseña(int usuarioId)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(usuarioId);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);

            // TODO: Agregar campo en usuario o una tabla nueva con el ultimo
            // codigo de validacion.

            int nuevoCodigoValidacion = new Random().Next(100000,999999);
            // Setear el nuevo codigo de validacion en la nueva tabla/campo.

            await _dbContext.SaveChangesAsync();

            await _mailingService.EnviarCodigoValidacion(usuario.Mail, nuevoCodigoValidacion);
        }
    }
}

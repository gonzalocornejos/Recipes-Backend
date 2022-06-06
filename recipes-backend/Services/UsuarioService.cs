namespace recipes_backend.Services
{
    using recipes_backend.Data;
    using recipes_backend.Dtos.Usuario.Authentication;
    using recipes_backend.Exceptions;
    using recipes_backend.Models.Domain;
    using recipes_backend.Models.Domain.Enums;
    using recipes_backend.Repositories.Interfaces;
    using recipes_backend.Services.Interfaces;
    using System.Net;
    using System.Threading.Tasks;

    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository _genericRepository;

        private readonly IUsuarioRepository _usuarioRepository;

        private readonly IMailingService _mailingService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMailingService mailingService, IGenericRepository genericRepository)
        {
            _usuarioRepository = usuarioRepository;
            _mailingService = mailingService;
            _genericRepository = genericRepository;
        }


        public async Task Loguearse(LoguearseDTO credenciales)
        {
            if (!await _usuarioRepository.VerificarCredencialesLogueo(credenciales))
                throw new AppException("Credenciales no validas", HttpStatusCode.Unauthorized);           
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

            await _genericRepository.GuardarCambiosAsync();

            await _mailingService.EnviarCodigoValidacion(usuario.Mail, nuevoCodigoValidacion);
        }

        public async Task Registrarse(RegistroDTO credenciales)
        {
            if (credenciales.Contraseña != credenciales.ContraseñaRepetida)
                throw new AppException("Las contraseñas no coinciden", HttpStatusCode.BadRequest);

            var usuario = new Usuario(credenciales.Email.Trim(), credenciales.Alias, credenciales.Contraseña, false, credenciales.Alias, "", TipoUsuario.Visitante);
            await _genericRepository.Agregar(usuario);
            await _genericRepository.GuardarCambiosAsync();

            await _mailingService.EnviarMaildeActivacion(credenciales.Email.Trim(), credenciales.Alias);
        }

        public async Task ChequearPrimerPasoRegistro(PrimerPasoRegistroDTO credencialesPrueba)
        {
            var usuarioEmail = await _usuarioRepository.BuscarUsuarioPorMail(credencialesPrueba.Email.Trim());
            if (usuarioEmail != null)
                throw new AppException("El email ya existe", HttpStatusCode.BadRequest);

            var usuarioNickname = await _usuarioRepository.BuscarUsuario(credencialesPrueba.Alias);
            if (usuarioNickname != null)
                throw new AppException("El alias ya existe", HttpStatusCode.BadRequest);            
        }

        public async Task ActivarUsuario(string alias)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(alias);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);
            usuario.ActivarUsuario();
            await _genericRepository.GuardarCambiosAsync();
        }
    }
}

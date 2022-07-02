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

        public async Task RecuperarContraseña(string mail)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorMail(mail);
            if (usuario == null)
                throw new AppException("Correo electronico no encontrado", HttpStatusCode.NotFound);

            int nuevoCodigoValidacion = new Random().Next(100000,999999);
            usuario.SetCodigoValidacion(nuevoCodigoValidacion);

            await _genericRepository.GuardarCambiosAsync();

            await _mailingService.EnviarCodigoValidacion(usuario.Mail, usuario.CodigoValidacion.Value);
        }

        public async Task ChequearCodigoValidacion(string email, RecuperarContraseñaDTO recuperacionData)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorMail(email);
            if (usuario == null)
                throw new AppException("Usuario no encontrado", HttpStatusCode.NotFound);

            if (usuario.CodigoValidacion != recuperacionData.CodigoValidacion)
                throw new AppException("El codigo de validacion no coincide con el enviado al mail", HttpStatusCode.BadRequest);
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
                throw new AppException("El email ya esta en uso", HttpStatusCode.BadRequest);

            var usuarioNickname = await _usuarioRepository.BuscarUsuario(credencialesPrueba.Alias.Trim());
            if (usuarioNickname != null)
            {
                var aliasSugeridos = await ObtenerAliasSugeridos(3, credencialesPrueba.Alias.Trim());
                throw new AppException($"El alias {credencialesPrueba.Alias.Trim()} ya esta en uso, puedes probar con {String.Join(", ", aliasSugeridos.ToArray())} ", HttpStatusCode.BadRequest);
            }                     
        }

        private async Task<List<string>> ObtenerAliasSugeridos(int cantidadAlias, string aliasOrigen)
        {
            var alias = new List<string>();
            while (cantidadAlias > 0)
            {
                var newAlias = $"{aliasOrigen}{new Random().Next(9999)}";
                if(await _usuarioRepository.BuscarUsuario(newAlias) == null)
                {
                    alias.Add(newAlias);
                    cantidadAlias--;
                }
            }
            return alias;
        }

        public async Task ActivarUsuario(string alias)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(alias);
            if (usuario == null)
                throw new AppException("Usuario Invalido", HttpStatusCode.NotFound);
            usuario.ActivarUsuario();
            await _genericRepository.GuardarCambiosAsync();
        }

        public async Task CambiarContraseña(string email, CambiarContraseñaDTO cambiarContraseñaData)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorMail(email);
            if (usuario == null)
                throw new AppException("Usuario no encontrado", HttpStatusCode.NotFound);

            usuario.CambiarContraseña(cambiarContraseñaData.NuevaContraseña);
            await _genericRepository.GuardarCambiosAsync();
        }
    }
}

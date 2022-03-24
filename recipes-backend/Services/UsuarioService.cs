namespace recipes_backend.Services
{
    using recipes_backend.Repositories.Interfaces;
    using recipes_backend.Services.Interfaces;
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}

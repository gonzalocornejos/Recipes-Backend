namespace recipes_backend.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Models.Domain;
    using recipes_backend.Repositories.Interfaces;
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dbContext;

        public UsuarioRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> BuscarUsuario(int usuarioId)
        {
            var usuario = await _dbContext.Usuario
                .Where(u => u.Id == usuarioId)
                .FirstOrDefaultAsync();
            return usuario;
        }
    }
}

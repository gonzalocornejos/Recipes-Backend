namespace recipes_backend.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Dtos.Usuario.Authentication;
    using recipes_backend.Models.Domain;
    using recipes_backend.Repositories.Interfaces;
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dbContext;

        public UsuarioRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> VerificarCredencialesLogueo(LoguearseDTO credenciales)
        {
            // Habria que guardar en la base todo en mayus/minus y hacer el toLower/toUpper en el dto
            return await _dbContext.Usuario
                .AnyAsync(u => u.NickName == credenciales.Alias.Trim() && u.Contraseña == credenciales.Contraseña); 
        }

        public async Task<Usuario> BuscarUsuario(int usuarioId)
        {
            var usuario = await _dbContext.Usuario
                .Include(r => r.Recetas)
                .Include(u => u.Favoritas)
                .Where(u => u.Id == usuarioId)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> BuscarUsuario(string nickName)
        {
            var usuario = await _dbContext.Usuario
                .Include(r => r.Recetas)
                .Include(u => u.Favoritas)
                .Where(u => u.NickName == nickName)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> BuscarUsuarioPorMail(string email)
        {
            var usuario = await _dbContext.Usuario
                .Where(u => u.NickName == email)
                .FirstOrDefaultAsync();
            return usuario;
        }
    }
}

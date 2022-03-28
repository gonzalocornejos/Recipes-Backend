namespace recipes_backend.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Models.Domain;
    using recipes_backend.Repositories.Interfaces;
    using System.Threading.Tasks;

    public class TipoPlatoRepository : ITipoPlatoRepository
    {
        private readonly DataContext _dbContext;

        public TipoPlatoRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TipoPlato> BuscarTipoPlato(int idTipoPlato)
        {           
            return await _dbContext.TipoPlato
                .Where(r => r.Id == idTipoPlato)
                .FirstOrDefaultAsync();            
        }
    }
}

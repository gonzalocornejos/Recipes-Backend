namespace recipes_backend.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Models.Domain;
    using recipes_backend.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly DataContext _dbContext;

        public IngredienteRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ingrediente>> ObtenerIngredientes()
        {
            return await _dbContext.Ingrediente
                .ToListAsync();
        }
    }
}

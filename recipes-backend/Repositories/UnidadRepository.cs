namespace recipes_backend.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using recipes_backend.Data;
    using recipes_backend.Models.Domain;
    using recipes_backend.Repositories.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UnidadRepository : IUnidadRepository
    {
        private readonly DataContext _dbContext;

        public UnidadRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unidad> ObtenerUnidadByNombre(string nombre)
        {
            return await _dbContext.Unidad
                .Where(x => x.Descripcion == nombre)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Unidad>> ObtenerUnidades()
        {
            return await _dbContext.Unidad
                .ToListAsync();
        }
    }
}

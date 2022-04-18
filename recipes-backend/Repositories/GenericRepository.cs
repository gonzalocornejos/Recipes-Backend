namespace recipes_backend.Repositories
{
    using recipes_backend.Data;
    using recipes_backend.Models.ORM;
    using recipes_backend.Repositories.Interfaces;
    using System.Threading.Tasks;

    public class GenericRepository : IGenericRepository
    {
        private readonly DataContext _dbContext;

        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Actualizar(Entity entity)
        {
            _dbContext.Update(entity);
            return Task.CompletedTask;
        }

        public Task Agregar(Entity entity)
        {
            _dbContext.Add(entity);
            return Task.CompletedTask;
        }

        public Task Eliminar(Entity entity)
        {
            _dbContext.Remove(entity);
            return Task.CompletedTask;
        }

        public Task GuardarCambios()
        {
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task GuardarCambiosAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

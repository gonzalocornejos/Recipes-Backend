namespace recipes_backend.Repositories.Interfaces
{
    using recipes_backend.Models.Domain;
    public interface IIngredienteRepository
    {
        Task<List<Ingrediente>> ObtenerIngredientes();
    }
}

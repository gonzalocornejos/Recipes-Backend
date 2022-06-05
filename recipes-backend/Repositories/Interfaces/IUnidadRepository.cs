namespace recipes_backend.Repositories.Interfaces
{
    using recipes_backend.Models.Domain;
    public interface IUnidadRepository
    {
        Task<List<Unidad>> ObtenerUnidades();
        Task<Unidad> ObtenerUnidadByNombre(string nombre);
    }
}

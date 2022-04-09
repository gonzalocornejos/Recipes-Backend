namespace recipes_backend.Repositories.Interfaces
{
    using recipes_backend.Models.Domain;

    public interface ITipoPlatoRepository
    {
        /// <summary>
        ///     Busca el tipo plato teniendo en cuenta
        ///     el id pasado por parametro
        /// </summary>
        /// <param name="idTipoPlato"></param>
        /// <returns>
        ///     El tipo plato encontrado
        /// </returns>
        Task<TipoPlato> BuscarTipoPlato(int idTipoPlato);

        Task<List<TipoPlato>> ObtenerTipoPlatos();
    }
}

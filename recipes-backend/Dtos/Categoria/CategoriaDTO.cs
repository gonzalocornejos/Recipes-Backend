namespace recipes_backend.Dtos.Categoria
{
    using recipes_backend.Models.Domain;

    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Item { get; set; }

        public CategoriaDTO() { }

        public CategoriaDTO(TipoPlato tipoPlato)
        {
            Id = tipoPlato.Id;
            Item = tipoPlato.Descripcion;
        }
    }

    public class CreateCategoriaDTO
    {
        public CategoriaDTO Categoria { get; set; }
    }
}

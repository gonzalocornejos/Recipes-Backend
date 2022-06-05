namespace recipes_backend.Dtos.Categoria
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Item { get; set; }
    }

    public class CreateCategoriaDTO
    {
        public CategoriaDTO Categoria { get; set; }
    }
}

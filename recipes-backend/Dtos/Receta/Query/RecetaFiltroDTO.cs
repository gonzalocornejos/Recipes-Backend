namespace recipes_backend.Dtos.Receta.Query
{
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;

    public class RecetaFiltroDTO
    {
        public List<CategoriaDTO> Categorias { get; set; }
        public List<IngredienteDTO> Ingredientes { get; set; }
    }
}

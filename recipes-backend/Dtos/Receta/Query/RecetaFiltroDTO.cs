namespace recipes_backend.Dtos.Receta.Query
{
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Unidad;

    public class RecetaFiltroDTO
    {
        public List<CategoriaDTO> Categorias { get; set; }
        public List<IngredienteDTO> Ingredientes { get; set; }
        public List<UnidadDTO> Unidades { get; set; }
    }
}

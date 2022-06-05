namespace recipes_backend.Dtos.Receta
{
    using System.ComponentModel.DataAnnotations;
    using recipes_backend.Dtos.Paso;
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    public class CrearRecetaDTO
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public int Porciones { get; set; }

        public List<ViewIngredienteDTO> Ingredientes { get; set; }

        public List<CreateCategoriaDTO> Categorias { get; set; }

        public List<PasoDTO> Pasos { get; set; }
    }
}

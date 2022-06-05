namespace recipes_backend.Dtos.Receta
{
    using System.ComponentModel.DataAnnotations;
    using recipes_backend.Dtos.Paso;
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    public class CrearRecetaDTO
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string Foto { get; set; }

        [Required]
        public int Porciones { get; set; }

        [Required]
        public List<ViewIngredienteDTO> Ingredientes { get; set; }

        [Required]
        public List<CategoriaDTO> Categorias { get; set; }
        [Required]
        public List<PasoDTO> Pasos { get; set; }
    }
}

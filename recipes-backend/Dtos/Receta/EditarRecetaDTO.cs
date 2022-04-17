namespace recipes_backend.Dtos.Receta
{
    using System.ComponentModel.DataAnnotations;

    public class EditarRecetaDTO
    {
        [Required]
        public string Nombre { get; set; }
    }
}

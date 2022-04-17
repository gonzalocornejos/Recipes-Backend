namespace recipes_backend.Dtos.Receta
{
    using System.ComponentModel.DataAnnotations;
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
        public int CantidadPersonas { get; set; }

        [Required]
        public int TipoPlatoId { get; set; }
    }
}

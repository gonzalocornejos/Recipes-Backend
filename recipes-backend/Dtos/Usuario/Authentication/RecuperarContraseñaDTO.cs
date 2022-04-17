namespace recipes_backend.Dtos.Usuario.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class RecuperarContraseñaDTO
    {
        [Required]
        public int CodigoValidacion { get; set; }
    }
}

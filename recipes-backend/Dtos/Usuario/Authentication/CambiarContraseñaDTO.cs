namespace recipes_backend.Dtos.Usuario.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class CambiarContraseñaDTO
    {
        [Required]
        public string NuevaContraseña { get; set; }
    }
}

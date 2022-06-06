namespace recipes_backend.Dtos.Usuario.Authentication
{
    public class RegistroDTO
    {
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Contraseña { get; set; }
        public string ContraseñaRepetida { get; set; }
    }

    public class PrimerPasoRegistroDTO
    {
        public string Email { get; set; }
        public string Alias { get; set; }
    }
}

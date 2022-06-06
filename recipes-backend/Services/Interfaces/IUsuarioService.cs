namespace recipes_backend.Services.Interfaces
{
    using recipes_backend.Dtos.Usuario.Authentication;

    public interface IUsuarioService
    {
        Task Loguearse(LoguearseDTO credenciales);
        Task RecuperarContraseña(int usuarioId);
        Task ChequearPrimerPasoRegistro(PrimerPasoRegistroDTO credencialesPrueba); 
        Task Registrarse(RegistroDTO credenciales);
        Task ActivarUsuario(string alias);
    }
}

namespace recipes_backend.Dtos.Multimedia
{
    using recipes_backend.Models.Domain.Enums;

    public class MultimediaDTO
    {
        public int MultimediaPasoId { get; set; }
        public TipoContenido TipoContenido { get; set; }
        public string Extension { get; set; }
        public string UrlContenido { get; set; }
    }
}

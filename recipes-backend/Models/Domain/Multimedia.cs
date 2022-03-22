namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Multimedia
    {
        [Key]
        public int Id { get; set; }

        public Paso Paso { get; set; }

        public TipoContenido TipoContenido { get; set; }

        public string Extension { get; set; }

        public string UrlContenido { get; set; }
    }   
}

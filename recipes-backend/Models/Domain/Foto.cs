namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Foto
    {
        [Key]
        public int Id { get; set; }

        public Receta Receta { get; set; }

        public string UrlFoto { get; set; }

        public string Extension { get; set; }
    }
}

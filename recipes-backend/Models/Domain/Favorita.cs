namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Favorita
    {
        [Key]
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Receta Recetas { get; set; }
    }
}

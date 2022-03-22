namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; } 

        public string Nombre { get; set; }
    }
}

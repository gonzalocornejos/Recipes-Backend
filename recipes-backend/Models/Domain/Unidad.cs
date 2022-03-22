namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Unidad
    {
        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }
    }
}

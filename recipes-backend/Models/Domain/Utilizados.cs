namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class Utilizados
    {
        [Key]
        public string Id { get; set; }

        public Receta Receta { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public int Cantidad { get; set; }

        public Unidad Unidad { get; set; }

        public string Observaciones { get; set; }
    }
}

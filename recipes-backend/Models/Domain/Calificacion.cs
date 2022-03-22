namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Calificacion
    {
        [Key]
        public int Id { get; set; }

        public Usuario Usuario{ get; set; }

        public Receta Receta { get; set; }

        public int Puntaje { get; set; }

        public string Comentarios{ get; set; }
    }
}

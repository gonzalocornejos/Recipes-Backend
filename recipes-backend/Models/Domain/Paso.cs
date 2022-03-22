namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Paso
    {
        [Key]
        public int Id { get; set; }

        public Receta Receta { get; set; }

        public int NroPaso { get; set; }

        public string Texto { get; set; }

        public List<Multimedia> Multimedias { get; set; }
    }
}

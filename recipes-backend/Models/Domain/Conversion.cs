namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Conversion
    {
        [Key]
        public int Id { get; set; }

        public Unidad UnidadOrigen { get; set; }

        public Unidad UnidadDestino { get; set; }

        public double FactorConversion { get; set; }
    }
}

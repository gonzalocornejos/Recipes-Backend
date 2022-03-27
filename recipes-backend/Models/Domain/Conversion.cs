namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Conversion : Entity
    {
        public Unidad UnidadOrigen { get; private set; }

        public Unidad UnidadDestino { get; private set; }

        public double FactorConversion { get; private set; }

        protected Conversion()
        {

        }

        public Conversion(Unidad unidadOrigen, Unidad unidadDestino, double factorConversion)
        {
            UnidadOrigen = unidadOrigen;
            UnidadDestino = unidadDestino;
            FactorConversion = factorConversion;
        }
    }
}

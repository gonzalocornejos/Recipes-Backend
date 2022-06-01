namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Conversion : Entity
    {
        private Unidad _unidadOrigen;
        private Unidad _unidadDestino;
        private double _factorConversion;

        public Unidad UnidadOrigen
        {
            get { return _unidadOrigen; }
            set { _unidadOrigen = value; }
        }

        public Unidad UnidadDestino
        {
            get { return _unidadDestino; }
            set { _unidadDestino = value; }
        }

        public double FactorConversion
        {
            get { return _factorConversion; }
            set { _factorConversion = value; }
        }

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

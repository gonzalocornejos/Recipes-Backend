namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Paso : Entity
    {
        public Receta Receta { get; private set; }

        public int NroPaso { get; private set; }

        public string Texto { get; private set; }

        private readonly List<Multimedia> _multimedias = new List<Multimedia>();
        public IReadOnlyList<Multimedia> Multimedias => _multimedias.ToList();

        protected Paso()
        {

        }

        public Paso(Receta receta, int nroPaso, string texto)
            : this()
        {
            Receta = receta;
            NroPaso = nroPaso;
            Texto = texto;
        }
    }
}

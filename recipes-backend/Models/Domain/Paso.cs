namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Paso : Entity
    {
        private Receta _receta;
        private int _nroPaso;
        private string _texto;
        private readonly List<Multimedia> _multimedias;

        public Receta Receta
        {
            get { return _receta; }
            set { _receta = value; }
        }

        public int NroPaso
        {
            get { return _nroPaso; }
            set { _nroPaso = value; }
        }

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public IReadOnlyList<Multimedia> Multimedias => _multimedias.ToList();

        protected Paso()
        {
            _multimedias = new List<Multimedia>();
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

namespace recipes_backend.Models.Domain
{
    using recipes_backend.Dtos.Multimedia;
    using recipes_backend.Models.ORM;
    public class Paso : Entity
    {
        private Receta _receta;
        private string _titulo;
        private int _nroPaso;
        private string _texto;
        private readonly List<Multimedia> _multimedias;

        public Receta Receta
        {
            get { return _receta; }
            set { _receta = value; }
        }
        public string Titulo { 
            get { return _titulo; }
            set { _titulo = value; }
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

        public Paso(Receta receta, int nroPaso, string texto, string titulo)
            : this()
        {
            Receta = receta;
            NroPaso = nroPaso;
            Texto = texto;
            Titulo = titulo;
        }

        public void AddMultimedias(List<String> multimedias)
        {
            foreach(var multimedia in multimedias)
            {
                _multimedias.Add(new Multimedia(this,Enums.TipoContenido.Foto,".jpg",multimedia));
            }
        } 
    }
}

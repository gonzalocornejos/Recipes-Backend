namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Receta : Entity
    {
        public Usuario Usuario { get; private set; }

        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }

        public string Foto { get; private set; }

        public int Porciones { get; private set; }

        public int CantidadPersonas { get; private set; }

        public TipoPlato TipoPlato { get; private set; }


        private readonly List<Foto> _fotos = new List<Foto>();
        public IReadOnlyList<Foto> Fotos => _fotos.ToList();


        private readonly List<Utilizados> _ingredientes = new List<Utilizados>();
        public IReadOnlyList<Utilizados> Ingredientes => _ingredientes.ToList();


        private readonly List<Paso> _pasos = new List<Paso>();
        public IReadOnlyList<Paso> Pasos => _pasos.ToList();


        private readonly List<Calificacion> _calificaciones = new List<Calificacion>();
        public IReadOnlyList<Calificacion> Calificaciones => _calificaciones.ToList();


        private readonly List<Favorita> _favorito = new List<Favorita>();
        public IReadOnlyList<Favorita> Favorito => _favorito.ToList();

        protected Receta()
        {

        }

        public Receta(Usuario usuario, string nombre, string descripcion, string foto,
            int porciones, int cantidadPersonas, TipoPlato tipoPlato) : this()
        {
            Usuario = usuario;
            Nombre = nombre;
            Descripcion = descripcion;
            Foto = foto;
            Porciones = porciones;
            CantidadPersonas = cantidadPersonas;
            TipoPlato = tipoPlato;
        }
    }
}

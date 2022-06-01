namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Calificacion : Entity
    {
        private Usuario _usuario;
        private Receta _receta;
        private int _puntaje;
        private string _comentarios;

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public Receta Receta
        {
            get { return _receta; }
            set { _receta = value; }
        }

        public int Puntaje
        {
            get { return _puntaje; }
            set { _puntaje = value; }
        }

        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }

        private Calificacion()
        {

        }

        public Calificacion(Usuario usuario, Receta receta, int puntaje, string comentarios)
            : this()
        {
            Usuario = usuario;
            Receta = receta;
            Puntaje = puntaje;
            Comentarios = comentarios;
        }
    }
}

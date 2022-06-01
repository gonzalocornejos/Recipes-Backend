namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Favorita : Entity
    {
        private Usuario _usuario;
        private Receta _receta;

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

        protected Favorita()
        {

        }

        public Favorita(Usuario usuario, Receta receta)
        {
            Usuario = usuario;
            Receta = receta;
        }
    }
}

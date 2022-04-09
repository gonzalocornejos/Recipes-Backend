namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Favorita : Entity
    {
        public Usuario Usuario { get; private set; }
        public Receta Receta { get; private set; }

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

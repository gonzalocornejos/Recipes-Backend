namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Calificacion : Entity
    {
        public Usuario Usuario { get; private set; }

        public Receta Receta { get; private set; }

        public int Puntaje { get; private set; }

        public string Comentarios { get; private set; }

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

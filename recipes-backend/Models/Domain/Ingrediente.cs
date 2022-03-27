using recipes_backend.Models.ORM;

namespace recipes_backend.Models.Domain
{
    public class Ingrediente : Entity
    {
        public string Nombre { get; private set; }

        protected Ingrediente()
        {

        }

        public Ingrediente(string nombre)
            : this()
        {
            Nombre = nombre;
        }
    }
}

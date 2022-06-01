using recipes_backend.Models.ORM;

namespace recipes_backend.Models.Domain
{
    public class Ingrediente : Entity
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

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

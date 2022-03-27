using recipes_backend.Models.ORM;

namespace recipes_backend.Models.Domain
{
    public class TipoPlato : Entity
    {
        public string Descripcion { get; private set; }

        protected TipoPlato()
        {

        }

        public TipoPlato(string descripcion)
            : this()
        {
            Descripcion = descripcion;
        }
    }
}

using recipes_backend.Models.ORM;

namespace recipes_backend.Models.Domain
{
    public class TipoPlato : Entity
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

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

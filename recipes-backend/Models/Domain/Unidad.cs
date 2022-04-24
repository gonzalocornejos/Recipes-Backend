namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Unidad : Entity
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        protected Unidad()
        {

        }

        public Unidad(string descripcion) 
            : this()
        {
            Descripcion = descripcion;
        }
    }
}

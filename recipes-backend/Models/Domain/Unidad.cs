namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Unidad : Entity
    {
        public string Descripcion { get; private set; }

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

namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Utilizados : Entity
    {
        public Receta Receta { get; private set; }

        public Ingrediente Ingrediente { get; private set; }

        public int Cantidad { get; private set; }

        public Unidad Unidad { get; private set; }

        public string Observaciones { get; private set; }

        protected Utilizados()
        {

        }

        public Utilizados(Receta receta, Ingrediente ingrediente, int cantidad, Unidad unidad, string observaciones)
            : this()
        {
            Receta = receta;
            Ingrediente = ingrediente;
            Cantidad = cantidad;
            Unidad = unidad;
            Observaciones = observaciones;
        }
    }
}

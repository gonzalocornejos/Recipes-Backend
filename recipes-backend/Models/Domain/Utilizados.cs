namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class Utilizados : Entity
    {
        private Receta _receta;
        private Ingrediente _ingrediente;
        private int _cantidad;
        private Unidad _unidad;
        private string _observaciones;

        public Receta Receta
        {
            get { return _receta; }
            set { _receta = value; }
        }

        public Ingrediente Ingrediente
        {
            get { return _ingrediente; }
            set { _ingrediente = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        public Unidad Unidad
        {
            get { return _unidad; }
            set { _unidad = value; }
        }

        public string Observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

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

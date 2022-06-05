namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;

    public class RecetaTipoPlato : Entity
    {
        private Receta _receta;
        private TipoPlato _tipoPlato;

        public Receta Receta
        {
            get { return _receta; }
            set { _receta = value; }
        }

        public TipoPlato TipoPlato
        {
            get { return _tipoPlato; }
            set { _tipoPlato = value;}
        }

        protected RecetaTipoPlato() { }

        public RecetaTipoPlato(Receta receta, TipoPlato tipo)
        {
            Receta = receta;
            TipoPlato = tipo;
        }
    }
}

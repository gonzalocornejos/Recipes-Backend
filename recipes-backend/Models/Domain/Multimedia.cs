namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.Domain.Enums;
    using recipes_backend.Models.ORM;

    public class Multimedia : Entity
    {
        private Paso _paso;
        private TipoContenido _tipoContenido;
        private string _extension;
        private string _urlContenido;

        public Paso Paso
        {
            get { return _paso; }
            set { _paso = value; }
        }

        public TipoContenido TipoContenido
        {
            get { return _tipoContenido; }
            set { _tipoContenido = value; }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public string UrlContenido
        {
            get { return _urlContenido; }
            set { _urlContenido = value; }
        }

        protected Multimedia()
        {

        }

        public Multimedia(Paso paso, TipoContenido tipoContenido, string extension, string urlContenido)
            : this()
        {
            Paso = paso;
            TipoContenido = tipoContenido;
            Extension = extension;
            UrlContenido = urlContenido;
        }
    }   
}

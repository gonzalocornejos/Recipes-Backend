namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.Domain.Enums;
    using recipes_backend.Models.ORM;

    public class Multimedia : Entity
    {
        public Paso Paso { get; private set; }

        public TipoContenido TipoContenido { get; private set; }

        public string Extension { get; private set; }

        public string UrlContenido { get; private set; }

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

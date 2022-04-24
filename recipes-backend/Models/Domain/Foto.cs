namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Foto : Entity
    {
        private Receta _receta;
        private string _urlFoto;
        private string _extension;

        public Receta Receta
        {
            get { return _receta; }
            set { _receta = value; }
        }

        public string UrlFoto
        {
            get { return _urlFoto; }
            set { _urlFoto = value; }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        protected Foto()
        {

        }

        public Foto(Receta receta, string urlFoto, string extension)
            : this()
        {
            Receta = receta;
            UrlFoto = urlFoto;
            Extension = extension;
        }
    }
}

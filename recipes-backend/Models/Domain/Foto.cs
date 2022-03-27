namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.ORM;
    public class Foto : Entity
    {
        public Receta Receta { get; private set; }

        public string UrlFoto { get; private set; }

        public string Extension { get; private set; }

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

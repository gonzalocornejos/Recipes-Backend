namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.Domain.Enums;
    using recipes_backend.Models.ORM;

    public class Usuario : Entity
    {
        public string Mail { get; private set; }

        public string NickName { get; private set; }

        public bool Habilitado { get; private set; }

        public string Nombre { get; private set; }

        public string Avatar { get; private set; }

        public TipoUsuario TipoUsuario { get; private set; }


        private readonly List<Receta> _recetas = new List<Receta>();
        public IReadOnlyList<Receta> Recetas => _recetas.ToList();


        private readonly List<Favorita> _favoritas = new List<Favorita>();
        public IReadOnlyList<Favorita> Favoritas => _favoritas.ToList();

        protected Usuario()
        {

        }

        public Usuario(string mail, string nickName, bool habilitado, string nombre, string avatar, TipoUsuario tipoUsuario)
            : this()
        {
            Mail = mail;
            NickName = nickName;
            Habilitado = habilitado;
            Nombre = nombre;
            Avatar = avatar;
            TipoUsuario = tipoUsuario;
        }

        public void CrearReceta(string nombre, string descripcion, string foto,
            int porciones, int cantidadPersonas, TipoPlato tipoPlato)
        {
            var receta = new Receta(this, nombre, descripcion, foto, 
                porciones, cantidadPersonas, tipoPlato);
            _recetas.Add(receta);
        }

        public void EliminarReceta(Receta recetaAEliminar)
        {
            _recetas.RemoveAll(receta => receta == recetaAEliminar);
        }
    }
}

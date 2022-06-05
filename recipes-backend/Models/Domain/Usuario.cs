namespace recipes_backend.Models.Domain
{
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Paso;
    using recipes_backend.Dtos.Utilizados;
    using recipes_backend.Models.Domain.Enums;
    using recipes_backend.Models.ORM;
    using System.Linq;

    public class Usuario : Entity
    {
        private string _mail;
        private string _nickName;
        private bool _habilitado;
        private string _nombre;
        private string _avatar;
        private TipoUsuario _tipoUsuario;
        private readonly List<Receta> _recetas;
        private readonly List<Favorita> _favoritas;

        private string _contraseña;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        public TipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public IReadOnlyList<Receta> Recetas => _recetas.ToList();

        public IReadOnlyList<Favorita> Favoritas => _favoritas.ToList();

        protected Usuario()
        {
            _recetas = new List<Receta>();
            _favoritas = new List<Favorita>();
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
            int porciones, int cantidadPersonas, List<TipoPlato> tiposPlato, List<PasoDTO> pasos, List<UtilizadoDTO> ingredientes)
        {
            var receta = new Receta(this, nombre, descripcion, foto, 
                porciones, cantidadPersonas);
            receta.AgregarPasos(pasos);
            receta.AgregarTiposPlato(tiposPlato);
            receta.AgregarIngredientes(ingredientes);
            _recetas.Add(receta);
        }

        public void EliminarReceta(Receta recetaAEliminar)
        {
            _recetas.RemoveAll(receta => receta == recetaAEliminar);
        }

        public void ToggleFavorito(Receta receta)
        {
            var favorita = _favoritas
                .Where(f => f.Receta == receta)
                .FirstOrDefault();

            if (favorita is null) {
                _favoritas.Add(new Favorita(this, receta));
                return;
            }
            _favoritas.Remove(favorita);
        }
    }
}

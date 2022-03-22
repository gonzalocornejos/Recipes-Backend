namespace recipes_backend.Models.Domain
{
    using recipes_backend.Models.Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Mail { get; set; }

        public string NickName { get; set; }

        public bool Habilitado { get; set; }

        public string Nombre { get; set; }

        public string Avatar { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public List<Receta> Recetas { get;set; }

        public List<Favorita> Favoritas { get; set; }
    }
}

namespace recipes_backend.Models.Domain
{
    using System.ComponentModel.DataAnnotations;
    public class Receta
    {
        [Key]
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Foto { get; set; }

        public int Porciones { get; set; }

        public int CantidadPersonas { get; set; }

        public TipoPlato TipoPlato { get; set; }

        public List<Foto> Fotos { get; set; }

        public List<Utilizados> Ingredientes { get; set; }

        public List<Paso> Pasos { get; set; }

        public List<Calificacion> Calificaciones { get; set; }
    }
}

namespace recipes_backend.Dtos.Receta
{
    public class CrearRecetaDTO
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Foto { get; set; }

        public int Porciones { get; set; }

        public int CantidadPersonas { get; set; }

        public int TipoPlatoId { get; set; }
    }
}

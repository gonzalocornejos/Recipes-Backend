namespace recipes_backend.Dtos.Receta.Query
{
    using recipes_backend.Dtos.Foto;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Paso;

    public class RecetaResultadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Porciones { get; set; }
        public double ValoracionPromedio { get; set; }
        public List<FotoDTO> FotosFinales { get; set; }
        public List<IngredienteDTO> Ingredientes { get; set; }
        public List<PasoDTO> Pasos { get; set; }

       public RecetaResultadoDTO()
       {
            FotosFinales = new List<FotoDTO>();
            Ingredientes =  new List<IngredienteDTO>();
            Pasos = new List<PasoDTO>();
       }
    }
}

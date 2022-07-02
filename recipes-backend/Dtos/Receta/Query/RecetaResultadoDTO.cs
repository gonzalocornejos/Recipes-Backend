namespace recipes_backend.Dtos.Receta.Query
{
    using recipes_backend.Dtos.Foto;

    public class RecetaResultadoDTO
    {
        public int RecipeId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Porciones { get; set; }
        public string NickName { get; set; }
        public decimal ValoracionPromedio { get; set; }
        public string FotoFinal { get; set; }
        public bool EsFavorito { get; set; }
    }
}

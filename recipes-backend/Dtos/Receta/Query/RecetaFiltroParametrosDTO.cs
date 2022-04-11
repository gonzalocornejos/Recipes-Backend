namespace recipes_backend.Dtos.Receta.Query
{
    public class RecetaFiltroParametrosDTO
    {
        public string Nombre { get; set; }
        public List<string> TipoPlatos { get; set; }
        public List<string> Ingredientes { get; set; }
        public List<string> IngredientesExcluidos { get; set; }
        public string NickName { get; set; }
    }
}

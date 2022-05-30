namespace recipes_backend.Dtos.Receta.Query
{
    public class RecetaFiltroParametrosDTO
    {
        public string Nombre { get; set; }
        public List<string> TipoPlatos { get; set; }
        public List<string> Ingredientes { get; set; }
        public List<string> IngredientesExcluidos { get; set; }
        public string NickName { get; set; }
        public string UsuarioLogueado { get; set; }
        public bool SoloFavoritos { get; set; }
        public bool SoloPropias { get; set; }
    }
}

namespace recipes_backend.Helpers.Query
{
    /// <summary>
    ///    Métodos para simplificar la creación de parámetros de SQL, y la
    ///    construcción de consultas complejas de forma programática.
    /// </summary>
    public class Type
    {
        public static TReturn HasPositive<TReturn>(int? value, TReturn thenResult, TReturn orElse)
        {
            if (value is null || value <= 0) return orElse;
            else return thenResult;
        }

        public static TReturn Has<TReturn>(string value, TReturn thenResult, TReturn orElse)
        {
            if (string.IsNullOrWhiteSpace(value)) return orElse;
            else return thenResult;
        }

        public static TReturn Has<TReturn>(List<string> value, TReturn thenResult, TReturn orElse)
        {
            if (value.Count == 0) return orElse;
            else return thenResult;
        }
    }
}

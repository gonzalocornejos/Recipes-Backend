namespace recipes_backend.Dtos.Utilizados
{
    using recipes_backend.Models.Domain;
    public class UtilizadoDTO
    {
        public Ingrediente Ingrediente { get; set; }
        public int Cantidad { get; set; }
        public Unidad Unidad { get; set; }
        public string Descripcion { get; set; }

        public UtilizadoDTO(Ingrediente ingrediente, int cantidad, Unidad unidad, string descripcion)
        {
            Ingrediente = ingrediente;
            Cantidad = cantidad;
            Unidad = unidad;
            Descripcion = descripcion;
        }

    }
}

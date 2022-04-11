namespace recipes_backend.Dtos.Paso
{
    using recipes_backend.Dtos.Multimedia;

    public class PasoDTO
    {
        public int PasoId { get; set; }
        public int NroPaso { get; set; }
        public string Descripcion { get; set; }
        public List<MultimediaDTO> Multimedias { get; set; }

        public PasoDTO()
        {
            Multimedias = new List<MultimediaDTO>();
        }
    }
}

﻿namespace recipes_backend.Dtos.Paso
{
    using recipes_backend.Dtos.Multimedia;

    public class PasoDTO
    {
        public int Number { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        //public List<MultimediaDTO> Multimedias { get; set; } = new List<MultimediaDTO>();
        public List<string> Media { get; set; }
    }
}

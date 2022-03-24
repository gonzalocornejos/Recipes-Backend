namespace recipes_backend.Helpers
{
    using AutoMapper;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Models.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecetaInfoDTO, Receta>();
        }
    }
}

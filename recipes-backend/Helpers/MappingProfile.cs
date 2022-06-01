namespace recipes_backend.Helpers
{
    using AutoMapper;
    using recipes_backend.Dtos.Categoria;
    using recipes_backend.Dtos.Ingrediente;
    using recipes_backend.Dtos.Receta;
    using recipes_backend.Models.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RecetaInfoDTO, Receta>();
            CreateMap<CategoriaDTO, TipoPlato>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Item))
                .ReverseMap();
            CreateMap<IngredienteDTO, Ingrediente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Item))
                .ReverseMap(); ;
        }
    }
}

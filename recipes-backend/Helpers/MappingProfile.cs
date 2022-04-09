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
            CreateMap<CategoriaDTO, TipoPlato>();
            CreateMap<IngredienteDTO, Ingrediente>();
        }
    }
}

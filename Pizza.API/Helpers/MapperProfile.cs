using AutoMapper;
using Pizza.API.Models;

namespace Pizza.API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<PizzaModel, PizzaDTO>().ReverseMap();
            CreateMap<IngredientModel, IngredientDTO>().ReverseMap();
        }
    }
}
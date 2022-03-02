using AutoMapper;
using EletroStockAPI.Context.Models;
using EletroStockAPI.Models;

namespace EletroStockAPI.Utilities
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
        }
    }
}

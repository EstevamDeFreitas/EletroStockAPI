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
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<CreditCard, CreditCardModel>().ReverseMap();
            CreateMap<CustomerAccount, CustomerAccountModel>().ReverseMap();
            CreateMap<Customer, CustomerCreateModel>().ReverseMap();
            CreateMap<Address, AddressCreateModel>().ReverseMap();
        }
    }
}

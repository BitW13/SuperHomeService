using AutoMapper;
using Common.Entity.ShoppingPlannerService;
using ShoppingPlannerService.WebApi.Models;

namespace ShoppingPlannerService.WebApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Purchase, CreatePurchase>()
                 .ReverseMap();
            CreateMap<TypeOfPurchase, CreateTypeOfPurchase>()
                .ReverseMap();
            CreateMap<ShoppingCategory, CreateShoppingCategory>()
                .ReverseMap();
        }
    }
}

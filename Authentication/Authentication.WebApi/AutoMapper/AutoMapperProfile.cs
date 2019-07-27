using Authentication.WebApi.Models;
using AutoMapper;
using Common.Entity.AuthenticationModel;

namespace Authentication.WebApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, LoginUser>()
                .ReverseMap();
            CreateMap<User, RegisterUser>()
                .ReverseMap();
        }
    }
}

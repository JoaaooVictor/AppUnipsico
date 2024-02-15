using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;
using AutoMapper;

namespace AppUnipsico.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto, UserBaseModel>();
        }
    }
}

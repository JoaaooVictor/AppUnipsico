using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;
using AutoMapper;

namespace AppUnipsico.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RequestLoginDto, UserBaseModel>()
                .ForMember(x => x.UserPassword, opt => opt.MapFrom(a => a.Password))
                .ForMember(x => x.UserCpf, opt => opt.MapFrom(x => x.Cpf));
        }
    }
}

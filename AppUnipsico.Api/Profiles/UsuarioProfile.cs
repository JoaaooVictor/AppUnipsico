using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;
using AutoMapper;

namespace AppUnipsico.Api.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RequisicaoLoginDTO, UsuarioModel>()
                .ForMember(x => x.UsuarioSenha, opt => opt.MapFrom(a => a.RequisicaoSenha))
                .ForMember(x => x.UsuarioCpf, opt => opt.MapFrom(x => x.RequisicaoCpf));
        }
    }
}

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
                .ForMember(x => x.Senha, opt => opt.MapFrom(a => a.RequisicaoSenha))
                .ForMember(x => x.Cpf, opt => opt.MapFrom(x => x.RequisicaoCpf));

            CreateMap<CriaUsuarioDTO, UsuarioModel>()
                .ForMember(x => x.Nome, opt => opt.MapFrom(a => a.NomeUsuario))
                .ForMember(x => x.Cpf, opt => opt.MapFrom(a => a.Cpf))
                .ForMember(x => x.Email, opt => opt.MapFrom(a => a.Email))
                .ForMember(x => x.Senha, opt => opt.MapFrom(a => a.Senha))
                .ForMember(x => x.TipoUsuarioId, opt => opt.MapFrom(a => a.TipoUsuarioId))
                .ForMember(x => x.DataNascimento, opt => opt.MapFrom(a => a.DataNascimento));
        }
    }
}

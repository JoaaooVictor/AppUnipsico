using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;
using AutoMapper;

namespace AppUnipsico.Api.Profiles
{
    public class ConsultaProfile : Profile
    {
        public ConsultaProfile()
        {
            CreateMap<RequisicaoAgendaConsultaDTO, ConsultaModel>()
                .ForMember(x => x.DataConsulta, opt => opt.MapFrom(x => x.RequisicaoDataConsulta))
                .ForMember(x => x.PacienteId, opt => opt.MapFrom(x => x.RequisicaoPacienteId))
                .ForMember(x => x.ConsultaId, opt => opt.MapFrom(x => x.RequisicaoConsultaId));
        }
    }
}

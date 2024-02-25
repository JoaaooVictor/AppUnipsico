using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Models.DTOs;
using AutoMapper;

namespace AppUnipsico.Api.Services.Impl
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly AppDbContext _context;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IMapper _mapper;

        public ConsultaServico(AppDbContext context, IMapper mapper, IUsuarioServico usuarioServico)
        {
            _context = context;
            _mapper = mapper;
            _usuarioServico = usuarioServico;
        }

        public async Task<RespostaAgendaConsultaDTO> AgendarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO)
        {
            var respostaAgendaDto = new RespostaAgendaConsultaDTO();

            if (agendaConsultaDTO is not null)
            {
                try
                {
                    var paciente = await _usuarioServico.BuscaUsuarioPorId(agendaConsultaDTO.RequisicaoPacienteId);

                    var consultaModel = new ConsultaModel()
                    {
                        ConsultaStatus = StatusConsulta.Agendada,
                        DataConsulta = agendaConsultaDTO.RequisicaoDataConsulta,
                        ConsultaId = agendaConsultaDTO.RequisicaoConsultaId,
                        PacienteId = agendaConsultaDTO.RequisicaoPacienteId,
                    };

                    await _context.Consultas.AddAsync(consultaModel);
                    await _context.SaveChangesAsync();

                    respostaAgendaDto.Erro = false;
                    respostaAgendaDto.Mensagem = "Consulta agendada!";
                }
                catch (Exception ex)
                {
                    respostaAgendaDto.Erro = true;
                    respostaAgendaDto.Mensagem = $"Erro ao agendar a consulta : {ex.Message}";
                }
            }

            return respostaAgendaDto;
        }
    }
}

using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly AppDbContext _context;

        public ConsultaServico(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TrataRetornoDTO> AgendarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            if (agendaConsultaDTO is not null)
            {
                try
                {
                    var consultaModel = new ConsultaModel()
                    {
                        ConsultaStatus = StatusConsulta.Agendada,
                        DataConsulta = agendaConsultaDTO.RequisicaoDataConsulta,
                        ConsultaId = agendaConsultaDTO.RequisicaoConsultaId,
                        PacienteId = agendaConsultaDTO.RequisicaoPacienteId,
                    };

                    await _context.Consultas.AddAsync(consultaModel);
                    await _context.SaveChangesAsync();

                    trataRetornoDTO.Erro = false;
                    trataRetornoDTO.Mensagem = "Consulta agendada!";
                }
                catch (Exception ex)
                {
                    trataRetornoDTO.Erro = true;
                    trataRetornoDTO.Mensagem = $"Erro ao agendar a consulta : {ex.Message}";
                }
            }

            return trataRetornoDTO;
        }

        public async Task<TrataRetornoDTO> DesmarcarConsulta(RequisicaoAgendaConsultaDTO agendaConsultaDTO)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            try
            {
                var consulta = await _context.Consultas.FindAsync(agendaConsultaDTO.RequisicaoConsultaId);

                if (consulta is not null)
                {
                    consulta.ConsultaStatus = StatusConsulta.Disponivel;

                    _context.Consultas.Remove(consulta);
                    await _context.SaveChangesAsync();

                    trataRetornoDTO.Erro = false;
                    trataRetornoDTO.Mensagem = "Consulta desmarcada com sucesso!";
                }
                else
                {
                    trataRetornoDTO.Erro = true;
                    trataRetornoDTO.Mensagem = "Consulta não encontrada.";
                }
            }
            catch (Exception ex)
            {
                trataRetornoDTO.Erro = true;
                trataRetornoDTO.Mensagem = $"Erro ao desmarcar a consulta: {ex.Message}";
            }

            return trataRetornoDTO;
        }

        public async Task<TrataRetornoDTO> EditarConsulta(ConsultaModel consulta)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            try
            {
                var consultaExiste = await _context.Consultas.FindAsync(consulta);

                if (consultaExiste is not null)
                {
                    var consultaAtualizada = new ConsultaModel
                    {
                        ConsultaId = consulta.ConsultaId,
                        ConsultaStatus = consulta.ConsultaStatus,
                        DataConsulta = consulta.DataConsulta,
                        PacienteId = consulta.PacienteId  
                    }; 

                    _context.Consultas.Update(consultaAtualizada);
                    await _context.SaveChangesAsync();

                    trataRetornoDTO.Erro = false;
                    trataRetornoDTO.Mensagem = "Consulta editada com sucesso!";

                }
                else
                {
                    trataRetornoDTO.Erro = true;
                    trataRetornoDTO.Mensagem = "Consulta não encontrada!";
                }
            }
            catch (Exception ex)
            {
                trataRetornoDTO.Erro = true;
                trataRetornoDTO.Mensagem = $"Erro ao editar a consulta: {ex.Message}";
            }

            return trataRetornoDTO;
        }

        public async Task<IEnumerable<ConsultaModel>> ListarConsultaPorMes(int ano, int mes)
        {
            var dataInicio = new DateTime(ano, mes, 1);
            var dataFim = dataInicio.AddMonths(1).AddDays(-1);

            return await _context.Consultas.Where(c => c.DataConsulta >= dataInicio && c.DataConsulta <= dataFim).ToListAsync();
        }

        public async Task<IEnumerable<ConsultaModel>> ListarConsultasPorPaciente(Guid pacienteId)
        {
            return await _context.Consultas.Where(c => c.PacienteId == pacienteId).ToListAsync();
        }

    }
}

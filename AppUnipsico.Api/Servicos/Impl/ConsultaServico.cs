using AppUnipsico.Api.Modelos;
using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Models;
using AppUnipsico.Models.DTOs;
using AppUnipsico.Models.Enums;
using AppUnipsico.Models.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class ConsultaServico : IConsultaServico
    {
        private readonly ApplicationDbContext _context;

        public ConsultaServico(ApplicationDbContext context)
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
                    var consultaModel = new Consulta()
                    {
                        ConsultaStatus = TipoStatusConsulta.Agendada,
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
                    consulta.ConsultaStatus = TipoStatusConsulta.Disponivel;

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

        public async Task<TrataRetornoDTO> EditarConsulta(Consulta consulta)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            try
            {
                var consultaExistente = await _context.Consultas.FindAsync(consulta);

                if (consultaExistente is not null)
                {
                    var consultaAtualizada = new Consulta
                    {
                        ConsultaId = consultaExistente.ConsultaId,
                        ConsultaStatus = consultaExistente.ConsultaStatus,
                        DataConsulta = consultaExistente.DataConsulta,
                        PacienteId = consultaExistente.PacienteId
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

        public async Task<IEnumerable<Consulta>> ListarConsultaPorMes(int ano, int mes)
        {
            var dataInicio = new DateTime(ano, mes, 1);
            var dataFim = dataInicio.AddMonths(1).AddDays(-1);

            return await _context.Consultas.Where(c => c.DataConsulta >= dataInicio && c.DataConsulta <= dataFim).ToListAsync();
        }

        public async Task<IEnumerable<Consulta>> ListarConsultasPorPaciente(Guid pacienteId)
        {
            return await _context.Consultas.Where(c => c.PacienteId == pacienteId).ToListAsync();
        }

        /// <summary>
        /// Testar novamente após refatoração
        /// </summary>
        /// <returns></returns>

        public async Task LerEInserirConsultas()
        {
            var caminhoArquivo = @"C:\Users\joaov\OneDrive\Documentos\Documentos PCC\dataconsulta.xlsx";

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(caminhoArquivo)))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet is not null)
                {
                    int rowCount = worksheet.Dimension.Rows;
                    var consultas = new List<Consulta>();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var dataString = worksheet.Cells[row, 1].Value.ToString();
                        if (DateTime.TryParse(dataString, out DateTime dataHora))
                        {
                            consultas.Add(new Consulta{ DataConsulta = dataHora });
                        }
                    }

                    await _context.AddRangeAsync(consultas);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}

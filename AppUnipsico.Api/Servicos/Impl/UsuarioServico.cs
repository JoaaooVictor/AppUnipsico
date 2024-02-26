using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Modelos.DTOs;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Api.Utilidades;
using AppUnipsico.Api.Utils;
using AppUnipsico.Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICriptografiaServico _criptografia;
        private readonly ITipoUsuarioServico _userTypeService;

        public UsuarioServico(IMapper mapper, ICriptografiaServico encryptService, ITipoUsuarioServico userTypeService, AppDbContext context)
        {
            _mapper = mapper;
            _criptografia = encryptService;
            _userTypeService = userTypeService;
            _context = context;
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosAlunos()
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Aluno && x.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosPacientes()
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Paciente && x.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosProfessores()
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Professor && x.Ativo).ToListAsync();
        }

        public async Task<TrataRetornoDTO> CriaUsuarioAsync(CriaUsuarioDTO criaUsuarioDto)
        {
            var trataRetornoDTO = new TrataRetornoDTO();
            var usuario = _mapper.Map<UsuarioModel>(criaUsuarioDto);
            var tipoUsuario = await _userTypeService.BuscaTipoUsuarioPorId(criaUsuarioDto.TipoUsuarioId);
            var usuarioEhExistente = await BuscaUsuarioPorCpf(usuario);

            if (usuarioEhExistente is null)
            {
                try
                {
                    if (criaUsuarioDto is not null && tipoUsuario is not null)
                    {
                        var usuarioModel = new UsuarioModel
                        {
                            Nome = criaUsuarioDto.NomeUsuario,
                            Cpf = FormatacaoUtilidades.FormataCpf(criaUsuarioDto.Cpf),
                            Email = criaUsuarioDto.Email,
                            Id = Guid.NewGuid(),
                            Ativo = true,
                            Senha = _criptografia.CriptografaSenha(criaUsuarioDto.Senha),
                            DataNascimento = FormatacaoUtilidades.FormataData(criaUsuarioDto.DataNascimento),
                            DataRegistro = DateTime.Now,
                            TipoUsuarioId = tipoUsuario.TipoUsuarioId,
                            TipoUsuario = null!,
                        };

                        await _context.Usuarios.AddAsync(usuarioModel);
                        await _context.SaveChangesAsync();

                        trataRetornoDTO.Mensagem = "Usuário registrado com sucesso!";
                        trataRetornoDTO.Erro = false;
                    }

                }
                catch (Exception ex)
                {
                    trataRetornoDTO.Erro = true;
                    trataRetornoDTO.Mensagem = $"Erro ao registrar usuário no banco. \nErro: {ex.Message}";
                }
            }
            else
            {
                trataRetornoDTO.Mensagem = "Usuário já cadastrado!";
                trataRetornoDTO.Erro = true;
            }

            return trataRetornoDTO;
        }

        public async Task<UsuarioModel> BuscaUsuarioPorId(Guid usuarioId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);
        }

        public async Task<UsuarioModel> BuscaUsuarioPorCpf(UsuarioModel usuarioModel)
        {
            var userCreated = await _context.Usuarios.SingleOrDefaultAsync(x => x.Cpf.Trim() == usuarioModel.Cpf.Trim());

            if (userCreated is not null)
            {
                return userCreated;
            }

            return usuarioModel;

        }

        public async Task<TrataRetornoDTO> LogarUsuarioAsync(RequisicaoLoginDTO requisicaoLoginDto)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            var usuario = _mapper.Map<UsuarioModel>(requisicaoLoginDto);

            var usuarioModel = await _context.Usuarios.Where(x => x.Cpf == FormatacaoUtilidades.FormataCpf(usuario.Cpf))
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync();

            if (usuarioModel is not null && usuarioModel.Senha is not null)
            {
                if (_criptografia.VerificaSenha(usuario.Senha, usuarioModel.Senha))
                {
                    trataRetornoDTO.DTO = GeraTokenJwt(usuarioModel);
                    return trataRetornoDTO;
                }
            }

            return trataRetornoDTO;
        }

        public async Task<RespostaLoginDTO> ValidaCredenciaisAsync(RequisicaoLoginDTO logaUsuarioDto)
        {
            var response = await LogarUsuarioAsync(logaUsuarioDto);

            if (response is not null)
            {
                return new RespostaLoginDTO()
                {
                    Logado = true,
                    Token = response.DTO.ToString(),
                    Mensagem = "Usuário logado com sucesso!"
                };
            }

            return new RespostaLoginDTO()
            {
                Logado = false,
                Token = null,
                Mensagem = "Credênciais inválidas!"
            };
        }

        public TrataRetornoDTO GeraTokenJwt(UsuarioModel usuario)
        {
            var trataRetornoDTO = new TrataRetornoDTO();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Segredos.ChaveSecretaToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim("IdUsuario", usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            trataRetornoDTO.DTO = tokenHandler.WriteToken(token);

            return trataRetornoDTO;
        }

    }
}

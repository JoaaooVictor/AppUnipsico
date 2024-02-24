using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Services.Interfaces;
using AppUnipsico.Api.Utils;
using AppUnipsico.Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Api.Services.Impl
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IMapper _mapper;
        private readonly ICriptografiaServico _criptografia;
        private readonly ITipoUsuarioServico _userTypeService;
        private readonly AppDbContext _context;

        public UsuarioServico(IMapper mapper, ICriptografiaServico encryptService, ITipoUsuarioServico userTypeService, AppDbContext context)
        {
            _mapper = mapper;
            _criptografia = encryptService;
            _userTypeService = userTypeService;
            _context = context;
        }

        public async Task CreateUserAsync(UsuarioModel usuarioModel)
        {
            await _context.Usuarios.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioModel> BuscaUsuarioPorId(Guid usuarioId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId);
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosAlunos()
        {
            return await BuscaUsuarioPorTipo((int)TipoUsuarioEnum.Aluno);
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosPacientes()
        {
            return await BuscaUsuarioPorTipo((int)TipoUsuarioEnum.Paciente);
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosProfessores()
        {
            return await BuscaUsuarioPorTipo((int)TipoUsuarioEnum.Professor);
        }

        public async Task<UsuarioModel> CriaUsuarioAsync(CriaUsuarioDTO criaUsuarioDto)
        {
            var tipoUsuario = await _userTypeService.GetUserTypeByIdAsync(criaUsuarioDto.UserTypeId);

            if (criaUsuarioDto != null && tipoUsuario != null)
            {
                var usuarioModel = new UsuarioModel
                {
                    UsuarioNome = criaUsuarioDto.UserName,
                    UsuarioCpf = FormatacaoUtilidades.FormataCpf(criaUsuarioDto.Cpf),
                    UsuarioEmail = criaUsuarioDto.Email,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAtivo = true,
                    UsuarioSenha = _criptografia.CriptografaSenha(criaUsuarioDto.Password),
                    UsuarioDataNascimento = FormatacaoUtilidades.FormataData(criaUsuarioDto.DateOfBirth),
                    UsuarioDataRegistro = DateTime.Now,
                    TipoUsuarioId = tipoUsuario.TipoUsuarioId,
                    TipoUsuario = null!,
                };

                var userCreated = await BuscaUsuarioPorCpf(usuarioModel);

                if (userCreated is null)
                {
                    await CreateUserAsync(usuarioModel);
                    return usuarioModel;
                }
                else
                {
                    throw new Exception("CPF já cadastrado!");
                }
            }

            return null;
        }

        public async Task<bool> ValidaCredenciaisAsync(RequisicaoLoginDTO logaUsuarioDto)
        {
            var response = await LogaUsuarioAsync(logaUsuarioDto);

            return response is null ? false : true;
        }

        public async Task<UsuarioModel> BuscaUsuarioPorCpf(UsuarioModel usuarioModel)
        {
            var userCreated = await _context.Usuarios.SingleOrDefaultAsync(x => x.UsuarioCpf.Trim() == usuarioModel.UsuarioCpf.Trim());

            if (userCreated is null)
            {
                return userCreated;
            }
            else
            {
                return usuarioModel;
            }
        }

        public async Task<UsuarioModel> LogaUsuarioAsync(RequisicaoLoginDTO requisicaoLoginDto)
        {
            var userModel = _mapper.Map<UsuarioModel>(requisicaoLoginDto);

            var user = await _context.Usuarios.Where(x => x.UsuarioCpf == FormatacaoUtilidades.FormataCpf(userModel.UsuarioCpf))
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync();

            if (user != null && !string.IsNullOrEmpty(userModel.UsuarioSenha))
            {
                if (_criptografia.VerificaSenha(userModel.UsuarioSenha, user.UsuarioSenha))
                {
                    return user;
                }
            }


            return null;
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaUsuarioPorTipo(int userTypeId)
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == userTypeId && x.UsuarioAtivo).ToListAsync();
        }
    }
}

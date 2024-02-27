using AppUnipsico.Api.Servicos.Interfaces;
using AppUnipsico.Api.Utilidades;
using AppUnipsico.Models;
using AppUnipsico.Models.Models.Usuarios;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICriptografiaServico _criptografia;

        public UsuarioServico(IMapper mapper, ICriptografiaServico encryptService, ApplicationDbContext context)
        {
            _mapper = mapper;
            _criptografia = encryptService;
            _context = context;
        }

        //    public async Task<IEnumerable<Usuario> BuscaTodosAlunos()
        //    {
        //        return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int) TipoUsuario.Aluno && x.Ativo).ToListAsync();
        //}

        //public async Task<IEnumerable<Usuario>> BuscaTodosPacientes()
        //{
        //    return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Paciente && x.Ativo).ToListAsync();
        //}

        //public async Task<IEnumerable<Usuario>> BuscaTodosProfessores()
        //{
        //    return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Professor && x.Ativo).ToListAsync();
        //}

        //public async Task<TrataRetornoDTO> CriaUsuarioAsync(CriaUsuarioDTO criaUsuarioDto)
        //{
        //    var trataRetornoDTO = new TrataRetornoDTO();
        //    var usuario = _mapper.Map<Usuario>(criaUsuarioDto);

        //    var usuarioEhExistente = await BuscaUsuarioPorCpf(usuario);

        //    if (usuarioEhExistente is null)
        //    {
        //        try
        //        {
        //            if (criaUsuarioDto is not null)
        //            {
        //                var Usuario = new Usuario
        //                {
        //                    Nome = criaUsuarioDto.NomeUsuario,
        //                    Cpf = FormatacaoUtilidades.FormataCpf(criaUsuarioDto.Cpf),
        //                    Email = criaUsuarioDto.Email,
        //                    Id = Guid.NewGuid(),
        //                    Ativo = true,
        //                    Senha = _criptografia.CriptografaSenha(criaUsuarioDto.Senha),
        //                    DataNascimento = FormatacaoUtilidades.FormataData(criaUsuarioDto.DataNascimento),
        //                    DataRegistro = DateTime.Now,
        //                    TipoUsuarioId = criaUsuarioDto.TipoUsuarioId,
        //                };

        //                await _context.Usuarios.AddAsync(Usuario);
        //                await _context.SaveChangesAsync();

        //                trataRetornoDTO.Mensagem = "Usuário registrado com sucesso!";
        //                trataRetornoDTO.Erro = false;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            trataRetornoDTO.Erro = true;
        //            trataRetornoDTO.Mensagem = $"Erro ao registrar usuário no banco. \nErro: {ex.Message}";
        //        }
        //    }
        //    else
        //    {
        //        trataRetornoDTO.Mensagem = "Usuário já cadastrado!";
        //        trataRetornoDTO.Erro = true;
        //    }

        //    return trataRetornoDTO;
        //}

        //public async Task<TrataRetornoDTO> CriaPacienteAsync(CriaUsuarioDTO criaUsuarioDto)
        //{
        //    var trataRetornoDTO = new TrataRetornoDTO();

        //    trataRetornoDTO = await CriaUsuarioAsync(new CriaUsuarioDTO()
        //    {
        //        TipoUsuarioId = (int)TipoUsuarioEnum.Paciente,
        //        Cpf = criaUsuarioDto.Cpf,
        //        DataNascimento = criaUsuarioDto.DataNascimento,
        //        Email = criaUsuarioDto.Email,
        //        NomeUsuario = criaUsuarioDto.NomeUsuario,
        //        Senha = criaUsuarioDto.Senha,
        //    });

        //    return trataRetornoDTO;
        //}

        //public async Task<TrataRetornoDTO> CriaProfessorAsync(CriaUsuarioDTO criaUsuarioDto)
        //{
        //    var trataRetornoDTO = new TrataRetornoDTO();

        //    trataRetornoDTO = await CriaUsuarioAsync(new CriaUsuarioDTO()
        //    {
        //        TipoUsuarioId = (int)TipoUsuarioEnum.Professor,
        //        Cpf = criaUsuarioDto.Cpf,
        //        DataNascimento = criaUsuarioDto.DataNascimento,
        //        Email = criaUsuarioDto.Email,
        //        NomeUsuario = criaUsuarioDto.NomeUsuario,
        //        Senha = criaUsuarioDto.Senha,
        //    });

        //    return trataRetornoDTO;
        //}

        //public async Task<TrataRetornoDTO> CriaAlunoAsync(CriaUsuarioDTO criaUsuarioDto)
        //{
        //    var trataRetornoDTO = new TrataRetornoDTO();

        //    trataRetornoDTO = await CriaUsuarioAsync(new CriaUsuarioDTO()
        //    {
        //        TipoUsuarioId = (int)TipoUsuarioEnum.Aluno,
        //        Cpf = criaUsuarioDto.Cpf,
        //        DataNascimento = criaUsuarioDto.DataNascimento,
        //        Email = criaUsuarioDto.Email,
        //        NomeUsuario = criaUsuarioDto.NomeUsuario,
        //        Senha = criaUsuarioDto.Senha,
        //    });

        //    return trataRetornoDTO;
        //}

        //public async Task<Usuario> BuscaUsuarioPorId(Guid usuarioId)
        //{
        //    return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);
        //}

        //public async Task<TrataRetornoDTO> BuscaUsuarioPorCpf(Usuario usuario)
        //{
        //    var trataRetornoDTO = new TrataRetornoDTO();
        //    try
        //    {
        //        trataRetornoDTO.DTO = await _context.Usuarios.SingleOrDefaultAsync(x => x.Cpf == usuario.Cpf.Trim());

        //        if (trataRetornoDTO.DTO is not null)
        //        {
        //            trataRetornoDTO.Erro = false;
        //            trataRetornoDTO.Mensagem = "Usuário já existente";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        trataRetornoDTO.Erro = false;
        //        trataRetornoDTO.Mensagem = $"Erro: {ex.Message}";
        //    }

        //    return trataRetornoDTO;

        //}

        //public async Task<TrataRetornoDTO> LogarUsuarioAsync(RequisicaoLoginDTO requisicaoLoginDto)
        //{
        //    var trataRetornoDTO = new TrataRetornoDTO();

        //    var usuario = _mapper.Map<Usuario>(requisicaoLoginDto);

        //    var Usuario = await _context.Usuarios.Where(x => x.Cpf == FormatacaoUtilidades.FormataCpf(usuario.Cpf))
        //        .Include(u => u.TipoUsuario)
        //        .FirstOrDefaultAsync();

        //    if (Usuario is not null && Usuario.Senha is not null)
        //    {
        //        if (_criptografia.VerificaSenha(usuario.Senha, Usuario.Senha))
        //        {
        //            trataRetornoDTO.DTO = GeraTokenJwt(Usuario);
        //            return trataRetornoDTO;
        //        }
        //    }

        //    return trataRetornoDTO;
        //}

        //public async Task<RespostaLoginDTO> ValidaCredenciaisAsync(RequisicaoLoginDTO logaUsuarioDto)
        //{
        //    var response = await LogarUsuarioAsync(logaUsuarioDto);

        //    if (response is not null)
        //    {
        //        return new RespostaLoginDTO()
        //        {
        //            Logado = true,
        //            Token = response.DTO.ToString(),
        //            Mensagem = "Usuário logado com sucesso!"
        //        };
        //    }

        //    return new RespostaLoginDTO()
        //    {
        //        Logado = false,
        //        Token = null,
        //        Mensagem = "Credênciais inválidas!"
        //    };
        //}

        public string GeraTokenJwt(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Segredos.ChaveSecretaToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim("idUsuario", usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

    }
}

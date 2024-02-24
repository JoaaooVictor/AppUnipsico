﻿using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Services.Interfaces;
using AppUnipsico.Api.Utilidades;
using AppUnipsico.Api.Utils;
using AppUnipsico.Models.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosAlunos()
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Aluno && x.UsuarioAtivo).ToListAsync();
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosPacientes()
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Paciente && x.UsuarioAtivo).ToListAsync();
        }

        public async Task<IEnumerable<UsuarioModel>> BuscaTodosProfessores()
        {
            return await _context.Usuarios.Where(x => x.TipoUsuarioId == (int)TipoUsuarioEnum.Professor && x.UsuarioAtivo).ToListAsync();
        }

        public async Task<UsuarioModel> CriaUsuarioAsync(CriaUsuarioDTO criaUsuarioDto)
        {
            var tipoUsuario = await _userTypeService.BuscaTipoUsuarioPorId(criaUsuarioDto.TipoUsuarioId);

            if (criaUsuarioDto != null && tipoUsuario != null)
            {
                var usuarioModel = new UsuarioModel
                {
                    UsuarioNome = criaUsuarioDto.UserName,
                    UsuarioCpf = FormatacaoUtilidades.FormataCpf(criaUsuarioDto.Cpf),
                    UsuarioEmail = criaUsuarioDto.Email,
                    UsuarioId = Guid.NewGuid(),
                    UsuarioAtivo = true,
                    UsuarioSenha = _criptografia.CriptografaSenha(criaUsuarioDto.Senha),
                    UsuarioDataNascimento = FormatacaoUtilidades.FormataData(criaUsuarioDto.DataNascimento),
                    UsuarioDataRegistro = DateTime.Now,
                    TipoUsuarioId = tipoUsuario.TipoUsuarioId,
                    TipoUsuario = null!,
                };

                var userCreated = await BuscaUsuarioPorCpf(usuarioModel);

                if (userCreated is null)
                {
                    await _context.Usuarios.AddAsync(usuarioModel);
                    await _context.SaveChangesAsync();
                    return usuarioModel;
                }
                else
                {
                    throw new Exception("CPF já cadastrado!");
                }
            }

            return null;
        }

        public async Task<UsuarioModel> BuscaUsuarioPorId(Guid usuarioId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId);
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

        public async Task<string> LogarUsuarioAsync(RequisicaoLoginDTO requisicaoLoginDto)
        {
            var usuario = _mapper.Map<UsuarioModel>(requisicaoLoginDto);

            var usuarioModel = await _context.Usuarios.Where(x => x.UsuarioCpf == FormatacaoUtilidades.FormataCpf(usuario.UsuarioCpf))
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync();

            if (usuarioModel != null && !string.IsNullOrEmpty(usuarioModel.UsuarioSenha))
            {
                if (_criptografia.VerificaSenha(usuario.UsuarioSenha, usuarioModel.UsuarioSenha))
                {
                    return GeraTokenJwt(usuarioModel);
                }
            }

            return null;
        }

        public async Task<string> ValidaCredenciaisAsync(RequisicaoLoginDTO logaUsuarioDto)
        {
            var response = await LogarUsuarioAsync(logaUsuarioDto);

            if (!string.IsNullOrEmpty(response))
            {
                return response.ToString();
            }
            else
            {
                return null;
            }
        }

        public string GeraTokenJwt(UsuarioModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Segredos.ChaveSecretaToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, usuario.UsuarioEmail),
                    new Claim(ClaimTypes.Name, usuario.UsuarioNome),
                    new Claim("IdUsuario", usuario.UsuarioId.ToString())
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
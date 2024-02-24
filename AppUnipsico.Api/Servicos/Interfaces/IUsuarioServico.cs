﻿using AppUnipsico.Api.Models;
using AppUnipsico.Models.DTOs;

namespace AppUnipsico.Api.Services.Interfaces
{
    public interface IUsuarioServico
    {
        public Task<IEnumerable<UsuarioModel>> BuscaTodosProfessores();
        public Task<IEnumerable<UsuarioModel>> BuscaTodosAlunos();
        public Task<IEnumerable<UsuarioModel>> BuscaTodosPacientes();
        public Task<UsuarioModel> CriaUsuarioAsync(CriaUsuarioDTO userModel);
        public Task<UsuarioModel> BuscaUsuarioPorId(Guid usuarioId);
        public Task<string> LogarUsuarioAsync(RequisicaoLoginDTO userLoginDto);
        public Task<string> ValidaCredenciaisAsync(RequisicaoLoginDTO userLoginDto);
        public string GeraTokenJwt(UsuarioModel usuario);
    }
}
using AppUnipsico.Api.Servicos.Interfaces;

namespace AppUnipsico.Api.Servicos.Impl
{
    public class CriptografiaServico : ICriptografiaServico
    {

        public string CriptografaSenha(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerificaSenha(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}

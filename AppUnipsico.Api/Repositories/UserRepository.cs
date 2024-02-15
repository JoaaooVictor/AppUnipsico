using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Api.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        private readonly IEncryptService _encryptService;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(AppDbContext context, IEncryptService encryptService, ILogger<UserRepository> logger)
        {
            _context = context;
            _encryptService = encryptService;
            _logger = logger;
        }

        public async Task CreateUserAsync(UserBaseModel userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
        }

        public async Task<UserBaseModel?> LoginUserAsync(UserBaseModel userModel)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserCpf == userModel.UserCpf);

                if (user != null && !string.IsNullOrEmpty(user.UserPassword))
                {
                    if (_encryptService.VerifyPassword(userModel.UserPassword, user.UserPassword))
                    {
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar fazer login do usuário.");
            }

            return null;
        }


        public async Task<UserBaseModel> GetUserByCpf(UserBaseModel userBaseModel)
        {
            return await _context.Users.Where(x => x.UserCpf == userBaseModel.UserCpf).FirstAsync();
        }

        public async Task<UserBaseModel> GetUserById(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<UserBaseModel>> GetUserByType(int userTypeId)
        {
            return await _context.Users.Where(x => x.UserTypeId == userTypeId && x.UserIsActive).ToListAsync();
        }
    }
}

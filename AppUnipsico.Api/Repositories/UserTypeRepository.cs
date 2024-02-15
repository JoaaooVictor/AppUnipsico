using AppUnipsico.Api.Data.Context;
using AppUnipsico.Api.Models;
using AppUnipsico.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppUnipsico.Api.Repositories
{
    public class UserTypeRepository
    {
        private readonly AppDbContext _context;

        public UserTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserTypeModel> GetUserTypeByIdAsync(int id)
        {
            return await _context.UserTypes.SingleOrDefaultAsync(x => x.UserTypeModelId == id);
        }
    }
}

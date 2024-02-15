using AppUnipsico.Api.Models;

namespace AppUnipsico.Api.Services.Interfaces
{
    public interface IUserTypeService
    {
        public Task<UserTypeModel> GetUserTypeByIdAsync(int id);
    }
}

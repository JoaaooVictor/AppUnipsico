using AppUnipsico.Api.Models;
using AppUnipsico.Api.Repositories;
using AppUnipsico.Api.Services.Interfaces;

namespace AppUnipsico.Api.Services.Impl
{
    public class UserTypeService : IUserTypeService
    {
        private readonly UserTypeRepository _repository;

        public UserTypeService(UserTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserTypeModel> GetUserTypeByIdAsync(int id)
        {
            return await _repository.GetUserTypeByIdAsync(id);
        }
    }
}

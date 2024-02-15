using AppUnipsico.Api.Models;
using AppUnipsico.Api.Models.Enums;
using AppUnipsico.Api.Repositories;
using AppUnipsico.Api.Services.Interfaces;
using AppUnipsico.Api.Utils;
using AppUnipsico.Models.DTOs;
using AutoMapper;

namespace AppUnipsico.Api.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepository _repository;
        private readonly IEncryptService _encryptService;
        private readonly IUserTypeService _userTypeService;

        public UserService(UserRepository repository, IMapper mapper, IEncryptService encryptService, IUserTypeService userTypeService)
        {
            _repository = repository;
            _mapper = mapper;
            _encryptService = encryptService;
            _userTypeService = userTypeService;
        }

        public async Task<UserBaseModel> CreateUserAsync(CreateUserDto createUser)
        {
            var userType = await _userTypeService.GetUserTypeByIdAsync(createUser.UserTypeId);

            if (createUser != null && userType != null)
            {
                var newUserModel = new UserBaseModel
                {
                    UserDisplayName = createUser.DisplayName,
                    UserName = createUser.UserName,
                    UserCpf = FormatUtility.FormatCpf(createUser.Cpf),
                    UserEmail = createUser.Email,
                    UserId = Guid.NewGuid(),
                    UserIsActive = true,
                    UserPassword = _encryptService.HashPassword(createUser.Password),
                    UserDateOfBirth = FormatUtility.FormatDateTime(createUser.DateOfBirth),
                    UserDateCreated = DateTime.Now,
                    UserTypeId = userType.UserTypeModelId,
                    UserType = null!,
                };

                var userCreated = await _repository.GetUserByCpf(newUserModel);

                if (userCreated is null)
                {
                    await _repository.CreateUserAsync(newUserModel);
                    return newUserModel;
                }
                else
                {
                    throw new Exception("CPF já cadastrado!");
                }
            }

            return null;
        }

        public async Task<UserBaseModel> Login(UserLoginDto userLoginDto)
        {
            var userModel = _mapper.Map<UserBaseModel>(userLoginDto);

            return await _repository.LoginUserAsync(userModel);
        }

        public async Task<IEnumerable<UserBaseModel>> GetAllPatients()
        {
            return await _repository.GetUserByType((int)UserTypeEnum.Patient);
        }

        public async Task<IEnumerable<UserBaseModel>> GetAllStudents()
        {
            return await _repository.GetUserByType((int)UserTypeEnum.Student);
        }

        public async Task<IEnumerable<UserBaseModel>> GetAllTeachers()
        {
            return await _repository.GetUserByType((int)UserTypeEnum.Teacher);
        }

    }
}

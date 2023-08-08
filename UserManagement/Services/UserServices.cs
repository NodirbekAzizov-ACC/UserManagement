using AutoMapper;
using UserManagement.Entity.Models;
using UserManagement.Services;
using UsersManagement.BusinessModels;
using UsersManagement.Helpers.Exceptions;
using UsersManagement.Repositories.Interfaces;

namespace UsersManagement.Services
{
	public class UserServices : IUserServices
	{
        private readonly IUserRepository _repository;
        private readonly ICSVService _csvService;
        private readonly IMapper _mapper;
        public UserServices(ICSVService csvService, IUserRepository repository, IMapper mapper)
        {
            _csvService = csvService;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> MergeFromCsvToDatabase(IFormFile file)
        {
            if(file is null)
            {
                throw new BadRequestException();
            }
            var users = GetUserRecordsFromCsv(file);
            bool result;
            foreach (var user in users)
            {
                var oldUser = await _repository.GetUser(user.UserIdentifier);
                var newUser = _mapper.Map<User>(user);
                // On mapping newUsed does not get GUID
                // For that reason I am forced to assign it manually
                newUser.UserId = user.UserIdentifier;
                if (oldUser is null)
                {
                    await _repository.CreateEntityAsync(newUser);
                }
                else
                {
                    _mapper.Map(user, oldUser);
                    _repository.UpdateEntity(oldUser, newUser);
                }
            }
            result = (await _repository.SaveChangesAsync()) > 0 ? true : false;
            return result;
        }
        public IEnumerable<UserDto> GetUserRecordsFromCsv(IFormFile file)
        {
            var users = _csvService.ReadCSV<UserDto>(file.OpenReadStream());
            return users ?? throw new NotFoundException();
        }
        
    }
}


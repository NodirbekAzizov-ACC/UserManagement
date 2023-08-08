using AutoMapper;
using UserManagement.Entity.Models;
using UserManagement.Services;
using UsersManagement.BusinessModels;
using UsersManagement.Helpers;
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
        public IEnumerable<User> GetUsersFromDatabase(int numberOfUsers = default, OrderBy orderBy = OrderBy.None)
        {
            if(numberOfUsers<0)
            {
                throw new BadRequestException($"{numberOfUsers} is not valid input for the current context");
            }
            List<User> users = orderBy switch
            {
                OrderBy.None when numberOfUsers == default => _repository.GetAllUser().ToList(),
                OrderBy.None when numberOfUsers != default => _repository.GetAllUser(numberOfUsers).ToList(),
                OrderBy.Ascending when numberOfUsers == default => _repository.GetAllUser().OrderBy(users => users.UserName).ToList(),
                OrderBy.Ascending when numberOfUsers != default => _repository.GetAllUser(numberOfUsers).OrderBy(users => users.UserName).ToList(),
                OrderBy.Descending when numberOfUsers == default => _repository.GetAllUser().OrderByDescending(users => users.UserName).ToList(),
                OrderBy.Descending when numberOfUsers != default => _repository.GetAllUser(numberOfUsers).OrderByDescending(users => users.UserName).ToList()
            };
            return users is null
                ? throw new NotFoundException("None record was found")
                : users;
        }
    }
}


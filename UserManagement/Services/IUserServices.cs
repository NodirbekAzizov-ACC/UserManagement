using UserManagement.Entity.Models;
using UsersManagement.BusinessModels;
using UsersManagement.Helpers;

namespace UsersManagement.Services;

public interface IUserServices
{
    public Task<bool> MergeFromCsvToDatabase(IFormFile file);
    public IEnumerable<UserDto> GetUserRecordsFromCsv(IFormFile file);
    public IEnumerable<User> GetUsersFromDatabase(int numberOfUsers = default, OrderBy orderBy = OrderBy.None);
}


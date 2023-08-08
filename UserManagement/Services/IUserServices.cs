using UsersManagement.BusinessModels;

namespace UsersManagement.Services;

public interface IUserServices
{
    Task<bool> MergeFromCsvToDatabase(IFormFile file);
    IEnumerable<UserDto> GetUserRecordsFromCsv(IFormFile file);
}


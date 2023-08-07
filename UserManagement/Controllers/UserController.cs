using Microsoft.AspNetCore.Mvc;
using UserManagement.Services;
using UsersManagement.BusinessModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ICSVService _csvService;
        public UserController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("/users/file")]
        public async Task<IActionResult> GetUsersCSV([FromForm] IFormFileCollection file)
        {
            var users = _csvService.ReadCSV<UserDtoCreate>(file[0].OpenReadStream());

            return Ok(users);
        }
    }
}


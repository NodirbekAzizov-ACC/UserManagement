using UserManagement.Entity.Models;
using UserManagement.Entity.SqlServer;
using UsersManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace UsersManagement.Repositories.Utilization
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly DbSet<User> _userCollection;
		public UserRepository(UserManagementContext context) : base(context)
		{
			_userCollection = context.Users;
		}
		public async Task<User> GetUser(Guid ID)
		{
			return await _userCollection.FindAsync(ID);
		}
        public IEnumerable<User> GetAllUser(int numberOfRecords = default)
        {
			if(numberOfRecords == default)
                return (from users in _userCollection
                        select users);
            return (from users in _userCollection
                    select users).Take(numberOfRecords);
        }
    }
}


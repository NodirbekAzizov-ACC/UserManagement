using System;
using UserManagement.Entity.Models;

namespace UsersManagement.Repositories.Interfaces
{
	public interface IUserRepository
	{
		public Task CreateEntitiesAsync(IEnumerable<User> users);
		public void UpdateEntities(IEnumerable<User> users);
		public Task CreateEntityAsync(User user);
		public void UpdateEntity(User user);
		public void UpdateEntity(User oldEntity, User newEntity);
        public Task<User> GetUser(Guid ID);
        public Task<int> SaveChangesAsync();
	}
}


using UserManagement.Entity.SqlServer;

namespace UsersManagement.Repositories
{
	public abstract class BaseRepository<T>
	{
		private readonly UserManagementContext _context;
		public BaseRepository(UserManagementContext context)
		{
			_context = context;
		}
		public virtual async Task CreateEntitiesAsync(IEnumerable<T> entities)
		{
			await _context.AddRangeAsync(entities);
		}
        public virtual void UpdateEntities(IEnumerable<T> entities)
        {
			_context.UpdateRange(entities);
        }
        public virtual async Task CreateEntityAsync(T entity)
        {
            await _context.AddAsync(entity);
        }
        public virtual void UpdateEntity(T entity)
        {
            _context.Update(entity);
        }
        public virtual void UpdateEntity(T oldEntity, T newEntity)
        {
            _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}


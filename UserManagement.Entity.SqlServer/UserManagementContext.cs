
using Microsoft.EntityFrameworkCore;
using UserManagement.Entity.Models;

namespace UserManagement.Entity.SqlServer
{
	public class UserManagementContext : DbContext
	{
		public UserManagementContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<User> Users { get; set; }
	}
}


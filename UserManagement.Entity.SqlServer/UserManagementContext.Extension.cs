using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Entity.SqlServer
{
	public static class UserManagementContextExtension
	{
		public static IServiceCollection AddUserManagementContext(
				this IServiceCollection services,
				string connectionString)
		{
			services.AddDbContext<UserManagementContext>(options
				=> options.UseSqlServer(connectionString));
			return services;
		}
	}
}


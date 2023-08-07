using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UserManagement.Entity.SqlServer
{
	public static class UserManagementContextExtension
	{
		public static IServiceCollection AddUserManagementContext(
				this IServiceCollection services,
                string nameOfAssembly,
                string connectionString = "Data Source=.;Initial Catalog=UsersDatabase;User Id=SA;Password=020299@z;TrustServerCertificate=true;MultipleActiveResultSets=true;Encrypt=true;"
				)
		{
			services.AddDbContext<UserManagementContext>(options
				=> options.UseSqlServer(connectionString, b=> b.MigrationsAssembly(nameOfAssembly)));
			return services;
		}
	}
}


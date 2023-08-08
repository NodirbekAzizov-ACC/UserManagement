using UserManagement.Entity.SqlServer;
using UserManagement.Services;
using UsersManagement.Repositories.Utilization;
using UsersManagement.Repositories.Interfaces;
using UsersManagement.Services;

namespace UsersManagement.Helpers
{
	public static class Services
	{
		public static IServiceCollection AddUserManagementAppServices(
            this IServiceCollection services, WebApplicationBuilder builder)
		{
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddUserManagementContext(connectionString: builder.Configuration.GetConnectionString("SqlServer")!,
                nameOfAssembly: typeof(Program).Assembly.GetName().Name!);
            services.AddScoped<ICSVService, CSVService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddAutoMapper(typeof(Program));
            return services;
        }
	}
}


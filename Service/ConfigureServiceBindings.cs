using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Model;
using Repository.Repositories;
using Service.Auth;
using Service.Tasks;

namespace Service
{
    public class ConfigureServiceBindings
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("postgre"));
                options.UseOpenIddict();
            });

            services.AddScoped<TaskRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<TaskService>();
            services.AddScoped<AuthService>();
        }
    }
}

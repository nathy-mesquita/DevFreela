using DevFreela.Core.Services;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevFreela.Infrastructure.Persistence.Repositories;

namespace DevFreela.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserSkillRepository, UserSkillRepository>();

            services.AddScoped<IAuthService, AuthService>();
            
            return services;
        }
    }
}
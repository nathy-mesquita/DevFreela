using MediatR;
using System.Reflection;
using FluentValidation.AspNetCore;
using DevFreela.Application.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = Assembly.GetExecutingAssembly(); 

            services.AddMediatR(assemblies); 
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            return services;
        }
    }
}
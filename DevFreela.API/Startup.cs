using DevFreela.Application;
using DevFreela.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration) 
            => _configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi();
            services.AddApplication(_configuration);
            services.AddInfrastructure(_configuration);
            services.AddSwaggerApiDoc();

            var connectionString = _configuration.GetConnectionString("DevFreelaCs");
            services.AddDbContext<DevFreelaDbContext>(
                options => options.UseSqlServer(connectionString)
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebApi();
            if(env.IsDevelopment())
            {
                app.UseSwaggerApiDoc();
            }
        }
    }
}

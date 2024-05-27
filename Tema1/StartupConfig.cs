using Project.Core.Services;
using Project.Database.Context;
using Project.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Project.Api
{
    public static class StartupConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ProdusService>();
            services.AddScoped<ReviewService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>();
            services.AddScoped<DbContext, ProjectDbContext>();

            services.AddScoped<ProdusRepository>();
            services.AddScoped<ReviewRepository>();
          
        }
    }
}



using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure
            (
                this IServiceCollection services,
                IConfiguration configuration
            )
        {
             services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
             configuration.GetConnectionString("DefaultConnection"), // Corrigindo o nome da conexão
             new MySqlServerVersion(new Version(8, 0, 28)), // Substitua a versão pelo número da sua versão do MySQL
             b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

    }
}

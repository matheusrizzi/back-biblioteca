using Basis.BibliotecaVirtual.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basis.BibliotecaVirtual.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BibliotecaDbContext>(options =>
            options.UseSqlServer("Server=PC-RIZZI;Database=basisdb;User Id=Basis;TrustServerCertificate=True;"));

        return services;
    }
}
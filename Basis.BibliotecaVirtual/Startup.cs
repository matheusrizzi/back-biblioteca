using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using Basis.BibliotecaVirtual.Application.Handlers.Assunto;
using Basis.BibliotecaVirtual.Application.Validators;
using Basis.BibliotecaVirtual.Domain.Repositories;
using Basis.BibliotecaVirtual.Infrastructure;
using Basis.BibliotecaVirtual.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Basis.BibliotecaVirtual.Startup))]
namespace Basis.BibliotecaVirtual;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;

        builder.Services.AddInfrastructure(configuration);

        builder.Services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.RegisterServicesFromAssembly(typeof(CreateAssuntoCommandHandler).Assembly);
        });

        //builder.Services.AddValidatorsFromAssembly(typeof(CreateAssuntoCommandValidator).Assembly);
        builder.Services.AddSingleton<IValidator<CreateAssuntoCommand>, CreateAssuntoCommandValidator>();
        builder.Services.AddScoped<IAssuntoRepository, AssuntoRepository>();
        builder.Services.AddScoped<IAutorRepository, AutorRepository>();
        builder.Services.AddScoped<ILivroRepository, LivroRepository>();
        builder.Services.AddScoped<IFormaCompraRepository, FormaCompraRepository>();
        builder.Services.AddScoped<ILivro_AutorRepository, Livro_AutorRepository>();
        builder.Services.AddScoped<ILivro_AssuntoRepository, Livro_AssuntoRepository>();
        builder.Services.AddScoped<ILivro_FormaCompraRepository, Livro_FormaCompraRepository>();
        builder.Services.AddScoped<ILivrosPorAutorViewRepository, LivrosPorAutorViewRepository>();

    }
}

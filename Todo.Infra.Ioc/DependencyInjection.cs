using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Interfaces;
using Todo.Application.Mappings;
using Todo.Application.Services;
using Todo.Domain.Interfaces;
using Todo.Infra.Data.Context;
using Todo.Infra.Data.Repositories;

namespace Todo.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
        opt => opt.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICardRepository, CardRepository>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICardService, CardService>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
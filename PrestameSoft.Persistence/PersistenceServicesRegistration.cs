using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrestameSoft.Application.Contracts.Persistence;
using PrestameSoft.Persistence.DatabaseContext;
using PrestameSoft.Persistence.Repositories;

namespace PrestameSoft.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }
}

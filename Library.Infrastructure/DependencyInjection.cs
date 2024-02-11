using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Data;
using Library.Application.Shared.Fines;
using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Fines;
using Library.Domain.Loans;
using Library.Domain.Reservations;
using Library.Infrastructure.Clock;
using Library.Infrastructure.Data;
using Library.Infrastructure.Fines;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        var connectionString = configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IBookCopyRepository, BookCopyRepository>();
        services.AddScoped<IFineRepository, FineRepository>();
        services.AddScoped<IFineService, FineService>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<LibraryDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        return services;
    }
}

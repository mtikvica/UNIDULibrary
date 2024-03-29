﻿using Library.Application.Abstractions.Caching;
using Library.Application.Abstractions.Clock;
using Library.Application.Abstractions.Data;
using Library.Application.Abstractions.OpenLibrary;
using Library.Domain.Abstractions;
using Library.Domain.AuthorBooks;
using Library.Domain.Authors;
using Library.Domain.BookCopies;
using Library.Domain.Books;
using Library.Domain.Fines;
using Library.Domain.Loans;
using Library.Domain.Publishers;
using Library.Domain.Reservations;
using Library.Infrastructure.Cache;
using Library.Infrastructure.Clock;
using Library.Infrastructure.Data;
using Library.Infrastructure.OpenLibrary;
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
        services.AddScoped<IPublisherRepository, PublisherRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IAuthorBookRepository, AuthorBookRepository>();

        services.AddScoped<IOpenLibraryService, OpenLibraryService>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<LibraryDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddHealthChecks(configuration);

        AddCaching(services, configuration);

        return services;
    }

    private static void AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);
    }

    private static void AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Cache") ??
                                    throw new ArgumentNullException(nameof(configuration));

        services.AddStackExchangeRedisCache(options => options.Configuration = connectionString);

        services.AddSingleton<ICacheService, CacheService>();
    }

}

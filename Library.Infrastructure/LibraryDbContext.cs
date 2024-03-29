﻿using Library.Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Library.Infrastructure;
public sealed class LibraryDbContext(DbContextOptions<LibraryDbContext> options, IPublisher publisher) : DbContext(options), IUnitOfWork
{
    private readonly IPublisher _publisher = publisher;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEventsAsync();

            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

    private async Task PublishDomainEventsAsync()
    {
        var domaninEvents = ChangeTracker.Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            }).ToList();

        foreach (var domainEvent in domaninEvents)
        {
            await _publisher.Publish(domainEvent);
        }
    }
}

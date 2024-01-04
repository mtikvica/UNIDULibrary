using Library.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Library.Core.BackgroundServices;
public class ReservationBackgroundService(ILogger<ReservationBackgroundService> logger, IServiceScopeFactory serviceScope) : BackgroundService
{
    private readonly TimeSpan _period = TimeSpan.FromDays(1);
    private readonly ILogger<ReservationBackgroundService> _logger = logger;
    private readonly IServiceScopeFactory _scopeFactory = serviceScope;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new(_period);

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            await ProcessReservationAsync();
        }
    }

    private async Task ProcessReservationAsync()
    {
        var reservationService = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IReservationService>();
        var bookCopyService = _scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IBookCopyService>();

        _logger.LogInformation("ReservationBackgroundService is starting.");

        var reservations = await reservationService.GetUnprocessedReservationsAsync();

        foreach (var reservation in reservations)
        {
            var bookCopy = await bookCopyService.GetBookCopyByIdAsync(reservation.BookCopyId);

            reservation.ProcessReservation();
            bookCopy.ProcessReservation();

            await reservationService.UpdateReservationAsync(reservation);
            await bookCopyService.UpdateBookCopyAsync(bookCopy);

        }
    }
}

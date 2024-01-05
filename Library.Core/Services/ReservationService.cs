using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class ReservationService(IReservationRepository reservationRepository, IFineService fineService, IMapper mapper, IBookCopyRepository bookCopyRepository) : IReservationService
{
    private readonly IReservationRepository _reservationRepository = reservationRepository;
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IFineService _fineService = fineService;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<Reservation>> GetReservationByCopyId(Guid copyId)
    {
        var reservations = await _reservationRepository.GetBy(x => x.BookCopyId == copyId).ToListAsync();

        return reservations;
    }

    public async Task<ReservationDto> AddReservationAsync(Guid studentID, Guid bookId)
    {
        var fines = await _fineService.GetUnpaidFinesForStudent(studentID);

        if (fines.Any())
        {
            throw new Exception($"Student with id : {studentID} has unpaid fines!");
        }
        var studentAlreadyHasReservationOnABook = await _reservationRepository.GetBy(x => x.StudentId == studentID && x.BookCopy.BookId == bookId).FirstOrDefaultAsync();

        if (studentAlreadyHasReservationOnABook is not null)
        {
            throw new LimitExcededException($"Student with id : {studentID} already has a reservation on this book!");
        }

        var studentReservations = _reservationRepository.GetBy(x => x.StudentId == studentID).Count();


        if (studentReservations > Constants.StudentReservationLimit)
        {
            throw new LimitExcededException($"Student with id : {studentID} has 3 reservations!");
        }

        var bookCopy = await _bookCopyRepository.GetBy(x => x.BookId == bookId && x.IsAvailable == true && x.IsReserved == false).FirstOrDefaultAsync() ?? throw new Exception($"There are no available book copies!");

        bookCopy.ProcessReservation();

        var reservation = new ReservationDto(bookCopy.CopyId, studentID);

        await _reservationRepository.AddAsync(_mapper.Map<Reservation>(reservation));
        await _bookCopyRepository.UpdateAsync(bookCopy);

        return reservation;
    }

    public async Task CancelReservation(Guid reservationId)
    {
        var reservation = await _reservationRepository.GetBy(x => x.ReservationId == reservationId).FirstOrDefaultAsync() ?? throw new Exception($"Reservation with id : {reservationId} was not found!");

        await _reservationRepository.DeleteAsync(reservation);
    }

    public async Task<IEnumerable<Reservation>> GetReservationsForStudent(Guid studentId)
    {
        var reservations = await _reservationRepository.GetBy(x => x.StudentId == studentId).ToListAsync();

        return reservations;
    }

    public async Task<Reservation> GetReservation(Guid reservationId)
    {
        var reservation = await _reservationRepository.GetBy(x => x.ReservationId == reservationId).FirstOrDefaultAsync() ?? throw new Exception($"Reservation with id : {reservationId} was not found!");

        return reservation;
    }

    public async Task<IEnumerable<Reservation>> GetUnprocessedReservationsAsync()
    {
        var unprocessedReservations = await _reservationRepository.GetBy(x => x.IsProcessed == false && DateTime.Now > x.ExpirationDate).ToListAsync();

        return unprocessedReservations;
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        await _reservationRepository.UpdateAsync(reservation);
    }
}

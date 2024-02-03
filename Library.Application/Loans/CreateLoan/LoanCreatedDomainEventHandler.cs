using Library.Domain.Abstractions;
using Library.Domain.BookCopies;
using Library.Domain.Loans.Event;
using MediatR;

namespace Library.Application.Loans.CreateLoan;
internal class LoanCreatedDomainEventHandler(
    IBookCopyRepository bookCopyRepository,
    IUnitOfWork unitOfWork)
    : INotificationHandler<LoanCreatedDomainEvent>
{
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(LoanCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var bookCopy = await _bookCopyRepository.GetByIdAsync(notification.BookCopyId, cancellationToken);

        bookCopy.ProcessLoan();

        _bookCopyRepository.Update(bookCopy);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

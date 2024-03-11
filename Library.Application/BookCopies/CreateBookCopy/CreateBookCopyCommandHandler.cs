using Library.Application.Abstractions.Messaging;
using Library.Domain.Abstractions;
using Library.Domain.BookCopies;

namespace Library.Application.BookCopies.CreateBookCopy;
internal class CreateBookCopyCommandHandler(
    IBookCopyRepository bookCopyRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateBookCopyCommand>
{
    private readonly IBookCopyRepository _bookCopyRepository = bookCopyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(CreateBookCopyCommand request, CancellationToken cancellationToken)
    {
        for (var i = 0; i < request.Ammount; i++)
        {
            _bookCopyRepository.Add(BookCopy.Create(request.BookId));
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Create("Copies created Succesfully!");
    }
}

using Library.Application.Abstractions.Messaging;

namespace Library.Application.BookCopies.CreateBookCopy;
public sealed record CreateBookCopyCommand(Guid BookId, int Ammount) : ICommand;
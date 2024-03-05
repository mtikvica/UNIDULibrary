using Library.Application.Abstractions.Messaging;

namespace Library.Application.Books.CreateBookWithOpenLibrary;
public sealed record CreateBookCommand(string Isbn) : ICommand<Guid>;

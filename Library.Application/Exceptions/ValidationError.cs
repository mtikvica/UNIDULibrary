namespace Library.Application.Exceptions;
public sealed record ValidationError(string PropertyName, string ErrorMessage);

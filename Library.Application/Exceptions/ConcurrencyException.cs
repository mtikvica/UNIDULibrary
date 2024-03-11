namespace Library.Infrastructure;

public sealed class ConcurrencyException : Exception
{
    public ConcurrencyException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ConcurrencyException() : base()
    {
    }

    public ConcurrencyException(string? message) : base(message)
    {
    }
}

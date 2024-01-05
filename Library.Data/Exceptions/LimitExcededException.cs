namespace Library.Data.Exceptions;
public class LimitExcededException : Exception
{
    public LimitExcededException(string message) : base(message)
    {
    }
}

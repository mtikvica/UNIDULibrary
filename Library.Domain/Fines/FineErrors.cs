using Library.Domain.Abstractions;

namespace Library.Domain.Fines;
public static class FineErrors
{
    public static Error AlreadyFined = new(
        "Fine.Fined",
        "Student is already fined!"
        );
}

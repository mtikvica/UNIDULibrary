using Library.Domain.Abstractions;

namespace Library.Domain.Fines;
public static class FineErrors
{
    public static Error Fined = new(
        "Fine.Fined",
        "Student is fined!"
        );
}

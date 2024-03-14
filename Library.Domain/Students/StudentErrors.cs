using Library.Domain.Abstractions;

namespace Library.Domain.Students;
public static class StudentErrors
{
    public static Error NotFound = new(
               "Student.NotFound",
                      "Student is not found!");
}

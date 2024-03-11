namespace Library.Domain.Abstractions;
public record Error(string Code, string Name)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
    public static readonly Error NotFound = new("not_found", "Not found");
    public static readonly Error Invalid = new("invalid", "Invalid");
    public static readonly Error Unauthorized = new("unauthorized", "Unauthorized");
    public static readonly Error Forbidden = new("forbidden", "Forbidden");
    public static readonly Error Conflict = new("conflict", "Conflict");
    public static readonly Error Internal = new("internal", "Internal");
    public static readonly Error NotImplemented = new("not_implemented", "Not implemented");
    public static readonly Error Unavailable = new("unavailable", "Unavailable");
    public static readonly Error Unknown = new("unknown", "Unknown");
}

using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Data.Context;

public class UNIDULibraryDbContext : DbContext
{
    public UNIDULibraryDbContext()
    {
    }

    public UNIDULibraryDbContext(DbContextOptions<UNIDULibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<BookCopy> BookCopies { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Fine> Fines { get; set; }

    public DbSet<InventoryState> InventoryStates { get; set; }

    public DbSet<Loan> Loans { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Staff> Staff { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(a => a.InventoryState)
            .WithOne(b => b.Book)
            .HasForeignKey<InventoryState>(i => i.BookId);
    }

}

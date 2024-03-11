namespace Library.API.SeedData.Models;

public class DepartmentSeedModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Guid LocationId { get; set; }
}

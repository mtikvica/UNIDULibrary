namespace Library.Core.Dtos;
public class DepartmentDto
{
    public DepartmentDto(string departmentName)
    {
        DepartmentName = departmentName;
    }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}

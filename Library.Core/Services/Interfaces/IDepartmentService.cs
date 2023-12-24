using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IDepartmentService
{
    Task<DepartmentDto> AddDepartmentAsync(string departmentName);
    Task<bool> DeleteDepartmentAsync(int id);
    Task<IEnumerable<DepartmentDto>> GetDeparmentsAsync();
    Task<DepartmentDto> GetDepartmentAsync(int id);
    Task<DepartmentDto> UpdateDepartmentAsync(Department department);
}
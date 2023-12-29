using Library.Core.Dtos;
using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IStaffService
{
    Task<StaffDto> AddStaffAsync(StaffDto staffDto);
    Task DeleteStaffAsync(Guid id);
    Task<StaffDto> GetStaffByIdAsync(Guid id);
    Task<StaffDto> UpdateStaffAsync(Staff staff);
}
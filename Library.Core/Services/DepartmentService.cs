using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Exceptions;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DepartmentDto>> GetDeparmentsAsync()
    {
        var departments = await _departmentRepository.GetAllAsync();
        return departments.Select(x => _mapper.Map<DepartmentDto>(x)).ToList();
    }

    public async Task<DepartmentDto> GetDepartmentAsync(int id)
    {
        var department = await _departmentRepository.GetBy(x => x.DepartmentId == id).FirstOrDefaultAsync();

        if (department is null)
        {
            throw new NotFoundException($"Department with id: {id} was not found!");
        }
        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<DepartmentDto> AddDepartmentAsync(string departmentName)
    {
        var deparmtentDto = new DepartmentDto(departmentName);

        var department = _mapper.Map<Department>(deparmtentDto);

        await _departmentRepository.AddAsync(department);

        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        await _departmentRepository.DeleteAsync(id);

        return true;
    }

    public async Task<DepartmentDto> UpdateDepartmentAsync(Department department)
    {
        await _departmentRepository.UpdateAsync(department);

        return _mapper.Map<DepartmentDto>(department);
    }
}

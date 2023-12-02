using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Exceptions;
using Library.Core.Services.Interfaces;
using Library.Data.Context;
using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class DepartmentService : IDepartmentService
{
    private readonly UNIDULibraryDbContext _context;
    private readonly IMapper _mapper;

    public DepartmentService(UNIDULibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentDto>> GetDeparmentsAsync()
    {
        var departments = await _context.Departments.AsNoTracking().ToListAsync();
        return departments.Select(x => _mapper.Map<DepartmentDto>(x)).ToList();
    }

    public async Task<Department> GetDepartmentAsync(int id)
    {
        var department = await _context.Departments.Where(x => x.DepartmentId == id).FirstOrDefaultAsync();

        if (department is null)
        {
            throw new NotFoundException($"Department with id: {id} was not found!");
        }
        return department;
    }

    public async Task<DepartmentDto> AddDepartmentAsync(string departmentName)
    {
        var deparmtentDto = new DepartmentDto(departmentName);

        var department = _mapper.Map<Department>(deparmtentDto);

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var department = await GetDepartmentAsync(id);

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<DepartmentDto> UpdateDepartmentAsync(int id, string deparmtentName)
    {
        var department = await GetDepartmentAsync(id);

        department.DepartmentName = deparmtentName;

        await _context.SaveChangesAsync();

        return _mapper.Map<DepartmentDto>(department);
    }
}

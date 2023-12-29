using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Core.Services;
public class StaffService(IStaffRepository staffRepository, IMapper mapper) : IStaffService
{
    private readonly IStaffRepository _staffRepository = staffRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<StaffDto> AddStaffAsync(StaffDto staffDto)
    {
        var staff = _mapper.Map<Staff>(staffDto);

        await _staffRepository.AddAsync(staff);

        return staffDto;
    }

    public async Task<StaffDto> GetStaffByIdAsync(Guid id)
    {
        var staff = await _staffRepository.GetBy(x => x.StaffId == id).FirstOrDefaultAsync();
        return _mapper.Map<StaffDto>(staff);
    }

    public async Task DeleteStaffAsync(Guid id)
    {
        var staff = await _staffRepository.GetBy(x => x.StaffId == id).FirstOrDefaultAsync();

        await _staffRepository.DeleteAsync(staff);
    }

    public async Task<StaffDto> UpdateStaffAsync(Staff staff)
    {
        await _staffRepository.UpdateAsync(staff);
        return _mapper.Map<StaffDto>(staff);
    }
}

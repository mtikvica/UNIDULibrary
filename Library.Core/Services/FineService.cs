using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Core.Services;
public class FineService(IFineRepository fineRepository, IMapper mapper) : IFineService
{
    private readonly IFineRepository _fineRepository = fineRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<Fine>> GetUnpaidFinesForStudent(Guid studentId)
    {
        var includes = new Expression<Func<Fine, object>>[]
        {
            x => x.Loan
        };

        var fines = await _fineRepository.GetByWithIncludesAsync(x => x.Loan.StudentId == studentId && x.PaidStatus == false, includes).ToListAsync();

        return fines;
    }

    public async Task<Fine> AddFineAsync(Guid loanId, int daysOverdue)
    {
        var fine = new FineDto(loanId, daysOverdue);

        return await _fineRepository.AddAsync(_mapper.Map<Fine>(fine));
    }
}

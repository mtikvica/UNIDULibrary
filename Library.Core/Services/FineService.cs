using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Core.Services;
public class FineService(IFineRepository fineRepository) : IFineService
{
    private readonly IFineRepository _fineRepository = fineRepository;

    public async Task<IEnumerable<Fine>> GetUnpaidFinesForStudent(Guid studentId)
    {
        var includes = new Expression<Func<Fine, object>>[]
        {
            x => x.Loan
        };

        var fines = await _fineRepository.GetByWithIncludesAsync(x => x.Loan.StudentId == studentId && x.PaidStatus == false, includes).ToListAsync();

        return fines;
    }
}

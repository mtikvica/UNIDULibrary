using Library.Data.Entities;

namespace Library.Core.Services.Interfaces;
public interface IFineService
{
    Task<IEnumerable<Fine>> GetUnpaidFinesForStudent(Guid studentId);
}
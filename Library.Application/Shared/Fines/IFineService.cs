namespace Library.Application.Shared.Fines;
public interface IFineService
{
    Task<IReadOnlyList<FineResponse>> GetUnpaidFinesByStundet(Guid studentId);
}

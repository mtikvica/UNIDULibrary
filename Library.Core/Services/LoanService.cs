using AutoMapper;
using Library.Core.Dtos;
using Library.Core.Services.Interfaces;
using Library.Data.Entities;
using Library.Data.Repositories.Interfaces;

namespace Library.Core.Services;
public class LoanService(ILoanRepository loanRepository, IReservationService reservationService, IFineService fineService, IMapper mapper)
{
    private readonly ILoanRepository _loanRepository = loanRepository;
    private readonly IReservationService _reservationService = reservationService;
    private readonly IFineService _fineService = fineService;
    private readonly IMapper _mapper = mapper;

    public async Task AddLoan(Guid copyId, Guid studentId)
    {
        var fines = await _fineService.GetUnpaidFinesForStudent(studentId);

        if (fines.Any())
        {
            throw new Exception($"Student with id : {studentId} has fines!");
        }

        var loan = new LoanDto(copyId, studentId);

        await _loanRepository.AddAsync(_mapper.Map<Loan>(loan));
    }
}

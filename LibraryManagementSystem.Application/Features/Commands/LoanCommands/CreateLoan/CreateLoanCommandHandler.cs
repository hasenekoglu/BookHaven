using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand,CreateLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public CreateLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<CreateLoanResponse> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = _mapper.Map<Loan>(request);
        loan.Id = Guid.NewGuid();

        await _loanRepository.AddAsync(loan);

        var loanCreateResponse = _mapper.Map<CreateLoanResponse>(loan);
        return loanCreateResponse;
    }
}
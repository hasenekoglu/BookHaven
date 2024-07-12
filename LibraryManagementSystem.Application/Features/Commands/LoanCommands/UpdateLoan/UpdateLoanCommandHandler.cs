using AutoMapper;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand,UpdateLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public UpdateLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<UpdateLoanResponse> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetSingleAsync(predicate: l => l.Id == request.Id);
        loan = _mapper.Map(request, loan);
        await _loanRepository.UpdateAsync(loan);
        var response = _mapper.Map<UpdateLoanResponse>(loan);
        return response;
    }
}
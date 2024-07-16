using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.DeleteLoan;

public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand, DeleteLoanResponse>
{

    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public DeleteLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<DeleteLoanResponse> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.Id);
        await _loanRepository.DeleteAsync(loan);

        var response = _mapper.Map<DeleteLoanResponse>(loan);
        return response;
    }
}
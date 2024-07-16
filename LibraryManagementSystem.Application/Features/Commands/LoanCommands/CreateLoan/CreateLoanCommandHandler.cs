using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Entities.Identity;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.CreateLoan;

public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand,CreateLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public CreateLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<CreateLoanResponse> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = _mapper.Map<Loan>(request);
        loan.Id = Guid.NewGuid();
        var userEmail = await _userManager.FindByEmailAsync(request.Email);
        loan.UserName = userEmail.UserName;
        
        await _loanRepository.AddAsync(loan);

        var loanCreateResponse = _mapper.Map<CreateLoanResponse>(loan);
        return loanCreateResponse;
    }
}
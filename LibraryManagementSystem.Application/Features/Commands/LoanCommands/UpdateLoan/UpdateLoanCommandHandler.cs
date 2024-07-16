using AutoMapper;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan;

public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand,UpdateLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public UpdateLoanCommandHandler(ILoanRepository loanRepository, IMapper mapper, UserManager<AppUser> userManager)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UpdateLoanResponse> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetSingleAsync(predicate: l => l.Id == request.Id);
        loan = _mapper.Map(request, loan);
        var userEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userEmail == null)
            throw new NotFoundUserException("Böyle bir email bulunamadı");
        loan.UserName = userEmail.UserName;
        await _loanRepository.UpdateAsync(loan);
        var response = _mapper.Map<UpdateLoanResponse>(loan);
        return response;
    }
}
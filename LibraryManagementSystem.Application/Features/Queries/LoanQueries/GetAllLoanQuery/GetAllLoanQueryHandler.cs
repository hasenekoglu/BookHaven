using AutoMapper;
using LibraryManagementSystem.Domain.Entities.Identity;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetAllLoanQuery;

public class GetAllLoanQueryHandler : IRequestHandler<GetAllLoanQuery,List<GetAllLoanResponse>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;
    private readonly IBookRepository _bookRepository;
    private readonly UserManager<AppUser> _userManager;

    public GetAllLoanQueryHandler(IMapper mapper, ILoanRepository loanRepository, IBookRepository bookRepository, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _loanRepository = loanRepository;
        _bookRepository = bookRepository;
        _userManager = userManager;
    }

    public async Task<List<GetAllLoanResponse>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
    {
        var loans = await _loanRepository.GetAll();
        var response = _mapper.Map<List<GetAllLoanResponse>>(loans);
        return response;
    }
}
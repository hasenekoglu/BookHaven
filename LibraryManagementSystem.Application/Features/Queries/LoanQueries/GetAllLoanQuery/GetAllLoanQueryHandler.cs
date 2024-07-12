using AutoMapper;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetAllLoanQuery;

public class GetAllLoanQueryHandler : IRequestHandler<GetAllLoanQuery,List<GetAllLoanResponse>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public GetAllLoanQueryHandler(IMapper mapper, ILoanRepository loanRepository)
    {
        _mapper = mapper;
        _loanRepository = loanRepository;
    }

    public async Task<List<GetAllLoanResponse>> Handle(GetAllLoanQuery request, CancellationToken cancellationToken)
    {
        var loans = await _loanRepository.GetAll();
        var response = _mapper.Map<List<GetAllLoanResponse>>(loans);
        return response;
    }
}
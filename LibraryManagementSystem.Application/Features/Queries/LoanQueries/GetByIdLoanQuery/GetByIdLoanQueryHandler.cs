using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetByIdLoanQuery;

public class GetByIdLoanQueryHandler : IRequestHandler<GetByIdLoanQuery,GetByIdLoanResponse>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IMapper _mapper;

    public GetByIdLoanQueryHandler(ILoanRepository loanRepository, IMapper mapper)
    {
        _loanRepository = loanRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdLoanResponse> Handle(GetByIdLoanQuery request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.Id);
        var response = _mapper.Map<GetByIdLoanResponse>(loan);
        return response;
    }
}
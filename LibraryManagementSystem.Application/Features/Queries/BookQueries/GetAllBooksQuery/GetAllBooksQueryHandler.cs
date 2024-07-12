using AutoMapper;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.BookQueries.GetAllBooksQuery;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<GetlAllBooksResponse>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;


    public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<GetlAllBooksResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var values = await _bookRepository.GetAll();
        var response = _mapper.Map<List<GetlAllBooksResponse>>(values);
        return response;
    }
}
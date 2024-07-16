using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;

using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.BookQueries.GetAllBooksQuery;

public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<GetlAllBooksResponse>>
{
    private readonly IBookRepository _bookRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;


    public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<GetlAllBooksResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var values = await _bookRepository.GetAll();
        var response = _mapper.Map<List<GetlAllBooksResponse>>(values);

        foreach (var booksResponse in response)
        {
            if (booksResponse.CategoryId is not null)
            {
                var category = await _categoryRepository.GetByIdAsync(booksResponse.CategoryId.Value);
                booksResponse.CategoryName = category?.Name;
            }
            
           
        }

        return response;
    }
}
using AutoMapper;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery;

public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery,GetByIdBookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetByIdBookQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<GetByIdBookResponse> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        Book book = await _bookRepository.GetByIdAsync(request.Id);
        if (book is null)
            throw new DatabaseValidationException("Kitap bulunamadı!");

        GetByIdBookResponse response = _mapper.Map<GetByIdBookResponse>(book);
        return response;

    }
}
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request);
        book.Id = Guid.NewGuid();

        await _bookRepository.AddAsync(book);
        
        CreateBookResponse createBookResponse = _mapper.Map<CreateBookResponse>(book);
     
        return createBookResponse;

    }
}
using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request);
        book.Id = Guid.NewGuid();

        await _bookRepository.AddAsync(book);
      
        
        
        CreateBookResponse createBookResponse = _mapper.Map<CreateBookResponse>(book);
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value);
        createBookResponse.CategoryName = category.Name;
     
        return createBookResponse;

    }
}
using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;

using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.UpdateBook;

public class UpdateBookCommandHandler :IRequestHandler<UpdateBookCommand,UpdateBookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<UpdateBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetSingleAsync(predicate: b => b.Id == request.Id);
        book = _mapper.Map(request, book);
        await _bookRepository.UpdateAsync(book);
        var response = _mapper.Map<UpdateBookResponse>(book);
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId.Value);
        response.CategoryName = category.Name;
        return response;

    }
}
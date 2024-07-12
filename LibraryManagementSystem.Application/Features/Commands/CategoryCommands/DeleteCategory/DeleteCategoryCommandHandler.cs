using AutoMapper;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.CategoryCommands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand,DeleteCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        await _categoryRepository.DeleteAsync(category);

        var response = _mapper.Map<DeleteCategoryResponse>(category);
        return response;
    }
}
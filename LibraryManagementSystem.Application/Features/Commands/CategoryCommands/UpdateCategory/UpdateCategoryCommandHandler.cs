using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;

using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.CategoryCommands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,UpdateCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetSingleAsync(predicate: c => c.Id == request.Id);
        category = _mapper.Map(request, category);
        await _categoryRepository.UpdateAsync(category);
        var response = _mapper.Map<UpdateCategoryResponse>(category);
        return response;
    }
}
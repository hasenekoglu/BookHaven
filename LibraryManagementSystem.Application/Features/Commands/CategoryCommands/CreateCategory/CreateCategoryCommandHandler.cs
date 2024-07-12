using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.CategoryCommands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,CreateCategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        category.Id = Guid.NewGuid();

        await _categoryRepository.AddAsync(category);

        var createCategoryResponse = _mapper.Map<CreateCategoryResponse>(category);
        return createCategoryResponse;

    }
}
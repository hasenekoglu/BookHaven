using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetByIdCategoryQuery;

public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        var response = _mapper.Map<GetByIdCategoryResponse>(category);
        return response;
    }
}
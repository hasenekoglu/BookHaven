using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetAllCategoryQuery;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery,List<GetAllCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllCategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAll();
        var response = _mapper.Map<List<GetAllCategoryResponse>>(categories);
        return response;
    }
}


using AutoMapper;
using CatalogBackend.Api.Features.Categories.Repositories;
using MediatR;

namespace CatalogBackend.Api.Features.Categories.Queries.GetCategory
{
    public class GetCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryQuery, CategoryDto>
  {
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
      var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new KeyNotFoundException($"Category with Id {request.Id} not found.");
      return _mapper.Map<CategoryDto>(category);
    }
  }
}

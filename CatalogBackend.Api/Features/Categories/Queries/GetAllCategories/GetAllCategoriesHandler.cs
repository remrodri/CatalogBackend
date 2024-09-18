using AutoMapper;
using CatalogBackend.Api.Features.Categories.Repositories;
using MediatR;

namespace CatalogBackend.Api.Features.Categories.Queries.GetAllCategories
{
  public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
  {
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoriesHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
      _mapper = mapper;
      _categoryRepository = categoryRepository;

    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
      var categories = await _categoryRepository.GetAllAsync(cancellationToken);
      return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }
  }
}

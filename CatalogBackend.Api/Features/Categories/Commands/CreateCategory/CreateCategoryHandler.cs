using AutoMapper;
using CatalogBackend.Api.Data.Entities;
using CatalogBackend.Api.Features.Categories.Repositories;
using MediatR;

namespace CatalogBackend.Api.Features.Categories.Commands.CreateCategory
{
  public class CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CreateCategoryCommand, CategoryDto>
  {
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
      var category = new Category
      {
        Id = Guid.NewGuid(),
        Name = request.Name,
        ParentCategoryId = request.ParentCategoryId
      };

      await _categoryRepository.AddAsync(category, cancellationToken);

      return _mapper.Map<CategoryDto>(category);
    }
  }
}

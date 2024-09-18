using MediatR;

namespace CatalogBackend.Api.Features.Categories.Commands.CreateCategory
{
  public class CreateCategoryCommand : IRequest<CategoryDto>
  {
    public required string Name { get; set; }
    public Guid? ParentCategoryId { get; set; }
  }
}

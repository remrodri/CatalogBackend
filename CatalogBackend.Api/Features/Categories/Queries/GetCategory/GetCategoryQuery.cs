using MediatR;

namespace CatalogBackend.Api.Features.Categories.Queries.GetCategory
{
    public class GetCategoryQuery : IRequest<CategoryDto>
  {
    public Guid Id { get; set; }
  }
}

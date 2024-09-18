using MediatR;

namespace CatalogBackend.Api.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}

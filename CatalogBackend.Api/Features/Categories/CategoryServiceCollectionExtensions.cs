using CatalogBackend.Api.Features.Categories.Repositories;

namespace CatalogBackend.Api.Features.Categories
{
  public static class CategoryServiceCollectionExtensions
  {
    public static IServiceCollection AddCategoryFeature(this IServiceCollection services)
    {
      services.AddScoped<ICategoryRepository, CategoryRepository>();

      return services;
    }
  }
}

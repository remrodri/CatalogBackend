using CatalogBackend.Api.Data.Entities;

namespace CatalogBackend.Api.Features.Categories.Repositories
{
  public interface ICategoryRepository
  {
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(Category category, CancellationToken cancellationToken);
    Task UpdateAsync(Category category, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
  }
}

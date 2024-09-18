using CatalogBackend.Api.Data;
using CatalogBackend.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogBackend.Api.Features.Categories.Repositories
{
  public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
  {
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Category category, CancellationToken cancellationToken)
    {
      await _context.Categories.AddAsync(category, cancellationToken);
      await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
      var category = await GetByIdAsync(id, cancellationToken);

      if (category != null)
      {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
      }
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
      return await _context.Categories
        .Include(c => c.SubCategories)
        .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
      return await _context.Categories
        .Include(c => c.SubCategories)
        .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
      _context.Categories.Update(category);
      await _context.SaveChangesAsync(cancellationToken);
    }
  }
}

namespace CatalogBackend.Api.Features.Categories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}

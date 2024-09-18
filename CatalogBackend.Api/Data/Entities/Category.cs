namespace CatalogBackend.Api.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }

        // Navigation property for self-referencing relationship
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = [];
    }
}

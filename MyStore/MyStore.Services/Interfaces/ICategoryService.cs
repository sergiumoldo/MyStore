using MyStore.NewFolder;

namespace MyStore.MyStore.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(int page);
        IEnumerable<Category> GetCategories(int page, string? text);
        Category? GetCategory(int id);
        Category InsertNew(Category category);
        bool IsDuplicate(string Categoryname);
        int Remove(Category category);
        Category Update(Category category);
    }
}
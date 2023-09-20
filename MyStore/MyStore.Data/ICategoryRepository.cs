
using MyStore.NewFolder;

namespace MyStore.Data
{
    public interface ICategoryRepository
    {
        Category? GetCategoryById(int id);
        Category Add(Category category);
        int Delete(Category category);
        Category Update(Category category);
        IEnumerable<Category> GetAll();
    }
}
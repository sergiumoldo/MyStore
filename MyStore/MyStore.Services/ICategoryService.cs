using MyStore.NewFolder;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        Category? GetCategory(int id);
    }
}
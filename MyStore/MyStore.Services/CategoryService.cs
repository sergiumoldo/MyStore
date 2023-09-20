using MyStore.Data;
using MyStore.NewFolder;

namespace MyStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public Category? GetCategory(int id)
        {
            var existingCategory = categoryRepository.GetCategoryById(id);
            return existingCategory;

            //return categoryRepository.GetCategoryById(id); ;
        }

    }
}
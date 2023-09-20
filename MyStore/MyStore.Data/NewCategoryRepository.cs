
using MyStore.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class NewCategoryRepository : ICategoryRepository
    {
        private readonly StoreContext storeContext;
        public NewCategoryRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Category Add(Category category)
        {
            throw new NotImplementedException();
        }

        public int Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category? GetCategoryById(int id)
        {
            return storeContext.Categories.Find(id);
        }

        public Category Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
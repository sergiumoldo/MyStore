using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.NewFolder;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly StoreContext context;
        public CategoriesController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var allCategories = context.Categories.ToList();
            return allCategories;
        }

        [HttpGet("{id}")]
        public Category? GetById(int id)
        {
            var category = context.Categories.Find(id);
            return category;
        }

        [HttpPut("{id}")]
        public Category Update(int id, Category category)
        {
            var cat = context.Categories.Find(id);

            if(cat != null)
            {
                TryUpdateModelAsync(cat);
                context.Categories.Update(category);
                context.SaveChanges();
            }
           
            return cat;
        }

        [HttpDelete("{id}")]
        public Category? Delete(int id)
        {
            var category = context.Categories.Find(id);
            if(category != null)
            {
                context.Remove(category);
                context.SaveChanges();
            }

            return category;
        }

        [HttpPost]
        public Category Insert(Category cat)
        {
            context.Add(cat);
            context.SaveChanges();

            return cat;
        }

    }
}

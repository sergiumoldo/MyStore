using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.NewFolder;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private readonly ICategoryRepository repository;

        public CategoriesController( ICategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            var allcategories = repository.GetAll();
            var modelToReturn = new List<CategoryModel>();  

            foreach(var category in allcategories)
            {
                modelToReturn.Add(category.ToCategoryModel());
            }

            return modelToReturn;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetById(int id)
        {
            var categoryFromDb = repository.GetCategoryById(id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            var model = new CategoryModel();

            model = categoryFromDb.ToCategoryModel();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Update(int id, CategoryModel model)
        {
            var cat = repository.GetCategoryById(id);

            if (cat == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(cat);

            repository.Update(model.ToCategory());

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = repository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            repository.Delete(category);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Insert(CategoryModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryToSave = new Category();

            categoryToSave = model.ToCategory();

            var addedEntity = repository.Add(categoryToSave);

            return CreatedAtAction(nameof(GetById), new {id = categoryToSave.Categoryid }, categoryToSave.ToCategoryModel);
        }

    }
}

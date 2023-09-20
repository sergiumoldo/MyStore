using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.MyStore.Data;
using MyStore.NewFolder;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperRepository repository;

        public ShippersController(IShipperRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ShipperModel> Get()
        {
            var allShippers = repository.GetAll();
            var modelToReturn = new List<ShipperModel>();

            foreach (var shipper in allShippers)
            {
                modelToReturn.Add(shipper.ToShipperModel());
            }

            return modelToReturn;
        }

        [HttpGet("{id}")]
        public ActionResult<ShipperModel> GetById(int id)
        {
            var shipperFromDb = repository.GetCategoryById(id);

            if (shipperFromDb == null)
            {
                return NotFound();
            }

            var model = shipperFromDb.ToShipperModel();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public ActionResult<ShipperModel> Update(int id, ShipperModel model)
        {
            var cat = repository.GetCategoryById(id);

            if (cat == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(cat);

            repository.Update(model.ToShipper());

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
        public IActionResult Insert(ShipperModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shipperToSave = new Shipper();

            shipperToSave = model.ToShipper();

            var addedEntity = repository.Add(shipperToSave);

            return CreatedAtAction(nameof(GetById), new { id = shipperToSave.Shipperid }, shipperToSave.ToShipperModel);
        }
    }
}

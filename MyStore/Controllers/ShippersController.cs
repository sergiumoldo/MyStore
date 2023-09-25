using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.MyStore.Services.Interfaces;
using MyStore.NewFolder;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly IShipperService shipperService;

        public ShippersController(IShipperService shipperService)
        {

            this.shipperService = shipperService;
        }

        [HttpGet]
        public IEnumerable<ShipperModel> Get(string? text, int pag = 1)
        {
            // implementam paginarea unor rezultate
            //2. adaugam un filtru de cautare in description dupa un nr de caractere
            var pageSize = 2;
            //le iau pe toate
            var allShippers = shipperService.GetShippers(pag, text);

            //1 2 - > 2(pagesize)*((3 -paginaCurenta)-1))
            //filtrez si iau doar cele de afisat pe pagina curenta
            //var currentPageItems = allCategories.Skip(pageSize * (pag - 1)).Take(pageSize).ToList();

            var modelsToReturn = new List<ShipperModel>();
            foreach (var shipper in allShippers)
            {
                modelsToReturn.Add(shipper.ToShipperModel());
            }

            return modelsToReturn;
        }


        [HttpGet("{id}")]
        public ActionResult<ShipperModel> GetById(int id)
        {

            var shipperFromDb = shipperService.GetShipper(id);

            if (shipperFromDb == null)
            {
                return NotFound();
            }
            var model = new ShipperModel();
            model = shipperFromDb.ToShipperModel();

            return Ok(model);
        }


        [HttpPut("{id}")]
        public ActionResult<ShipperModel> Update(int id, ShipperModel model)
        {
            var existingShipper = shipperService.GetShipper(id);
            if (existingShipper == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingShipper);

            var shipperToUpdate = new Shipper();
            shipperToUpdate = model.ToShipper();
            shipperService.Update(shipperToUpdate);

            return Ok(shipperToUpdate.ToShipperModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shipper = shipperService.GetShipper(id);

            if (shipper == null)
            {
                return NotFound();
            }

            shipperService.Remove(shipper);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(ShipperModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (shipperService.IsDuplicate(model.Companyname))
            {
                ModelState.AddModelError("CompanyName ", $"You can't have the duplicate items with the value {model.Companyname} on Companyname");
                return Conflict(ModelState);
            }

            var shipperToSave = new Shipper();
            shipperToSave = model.ToShipper();

            shipperService.InsertNew(shipperToSave);

            model.Shipperid = shipperToSave.Shipperid;

            return CreatedAtAction(nameof(GetById), new { id = shipperToSave.Shipperid }, model);
        }
    }
}
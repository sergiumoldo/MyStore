using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.NewFolder;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly StoreContext context;

        public ShippersController(StoreContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Shipper> Get()
        {
            var allShippers = context.Shippers.ToList();
            return allShippers;
        }

        [HttpGet("{id}")]
        public Shipper? GetById(int id)
        {
            var shipper = context.Shippers.Find(id);
            return shipper;
        }

        [HttpPost]
        public void Insert(Shipper shipper)
        { 
            context.Shippers.Add(shipper);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        public Shipper Update(int id, Shipper shipper)
        {
            var shipperToUpdate = context.Shippers.Find(id);

            if (shipperToUpdate != null)
            {
                shipperToUpdate.Companyname = shipper.Companyname; 

                context.SaveChanges();
            }

            return shipper;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deletedShipper = context.Shippers.Find(id);
            if(deletedShipper != null)
            {
                context.Shippers.Remove(deletedShipper);
                context.SaveChanges();
            }
        }
    }
}

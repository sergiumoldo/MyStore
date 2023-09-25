using MyStore.MyStore.Data.Interfaces;
using MyStore.MyStore.Services.Interfaces;
using MyStore.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }


        public Shipper? GetShipper(int id)
        {
            var existingShipper = shipperRepository.GetShipperById(id);
            return existingShipper;
        }


        public IEnumerable<Shipper> GetShippers(int page)
        {

            return shipperRepository.GetAll(page);
        }

        public IEnumerable<Shipper> GetShippers(int page, string text)
        {

            return shipperRepository.GetAll(page, text);
        }

        public Shipper InsertNew(Shipper shipper)
        {

            return shipperRepository.Add(shipper);
        }


        public int Remove(Shipper shipper)
        {
            return shipperRepository.Delete(shipper);
        }

        public Shipper Update(Shipper shipper)
        {
            return shipperRepository.Update(shipper);
        }

        public bool IsDuplicate(string companyName)
        {
            var shippers = shipperRepository.GetAll();//1
            shippers = shippers.Where(x => x.Companyname == companyName);//2
            shippers.Where(x => x.Phone.Contains("07"));//3
                                                               //.ToList();//load in memory

            return shippers.Any();
        }

    }
}
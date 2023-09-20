﻿
using MyStore.MyStore.Data;
using MyStore.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly StoreContext storeContext;

        public ShipperRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Shipper? GetCategoryById(int id)
        {
             var shipper =  storeContext.Shippers.Find(id);
            return shipper;
        }

        public Shipper Add(Shipper shipper)
        {
            var addedEntity = storeContext.Shippers.Add(shipper).Entity;
            storeContext.SaveChanges();

            return addedEntity;
        }

        public int Delete(Shipper shipper)
        {
            storeContext.Shippers.Remove(shipper);
            return  storeContext.SaveChanges();
        }

        public Shipper Update(Shipper shipper)
        {
            var updatedEntity = storeContext.Shippers.Update(shipper).Entity;
            storeContext.SaveChanges();

            return updatedEntity;
        }

        public IEnumerable<Shipper> GetAll()
        {
            return storeContext.Shippers.ToList();
        }
    }
}

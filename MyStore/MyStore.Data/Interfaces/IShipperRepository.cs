using MyStore.NewFolder;

namespace MyStore.MyStore.Data.Interfaces
{
    public interface IShipperRepository
    {
        Shipper Add(Shipper shipper);
        int Delete(Shipper shipper);
        IEnumerable<Shipper> GetAll(int page);
        IQueryable<Shipper> GetAll();
        IQueryable<Shipper> GetAll(int page, string? text);
        Shipper? GetShipperById(int id);
        Shipper Update(Shipper shipper);
    }
}

using MyStore.NewFolder;

namespace MyStore.MyStore.Data
{
    public interface IShipperRepository
    {
        Shipper? GetCategoryById(int id);
        Shipper Add(Shipper category);
        int Delete(Shipper category);
        Shipper Update(Shipper category);
        IEnumerable<Shipper> GetAll();
    }
}

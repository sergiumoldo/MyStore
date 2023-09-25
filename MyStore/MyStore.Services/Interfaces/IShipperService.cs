using MyStore.NewFolder;

namespace MyStore.MyStore.Services.Interfaces
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetShippers(int page);
        IEnumerable<Shipper> GetShippers(int page, string? text);
        Shipper? GetShipper(int id);
        Shipper InsertNew(Shipper category);
        bool IsDuplicate(string Categoryname);
        int Remove(Shipper category);
        Shipper Update(Shipper category);
    }
}

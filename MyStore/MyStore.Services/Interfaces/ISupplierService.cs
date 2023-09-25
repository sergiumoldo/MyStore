using MyStore.NewFolder;

namespace MyStore.MyStore.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers(int page);
        IEnumerable<Supplier> GetSuppliers(int page, string? text);
        Supplier? GetSupplier(int id);
        Supplier InsertNew(Supplier supplier);
        bool IsDuplicate(string SupplierName);
        int Remove(Supplier supplier);
        Supplier Update(Supplier supplier);
    }
}

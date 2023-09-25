using MyStore.NewFolder;

namespace MyStore.MyStore.Data.Interfaces
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier category);
        int Delete(Supplier category);
        IEnumerable<Supplier> GetAll(int page);
        IQueryable<Supplier> GetAll();
        IQueryable<Supplier> GetAll(int page, string? text);
        Supplier? GetSupplierById(int id);
        Supplier Update(Supplier category);
    }
}

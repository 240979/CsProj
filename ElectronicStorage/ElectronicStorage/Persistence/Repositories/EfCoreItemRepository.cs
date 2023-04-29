using ElectronicStorage.Persistence.Models;

namespace ElectronicStorage.Persistence.Repositories;

public class EfCoreItemRepository : EfCoreRepository<Item, ElectronicStorageContext>
{
    public EfCoreItemRepository(ElectronicStorageContext context) : base(context)
    {
        
    }
}
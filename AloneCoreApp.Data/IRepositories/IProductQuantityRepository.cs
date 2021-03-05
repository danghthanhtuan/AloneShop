using AloneCoreApp.Data.Entities;
using AloneCoreApp.Infrastructure.Interfaces;

namespace AloneCoreApp.Data.IRepositories
{
    public interface IProductQuantityRepository : IRepository<ProductQuantity, int>
    {
    }
}

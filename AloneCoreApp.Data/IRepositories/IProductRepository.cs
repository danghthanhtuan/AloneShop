using AloneCoreApp.Data.Entities;
using AloneCoreApp.Infrastructure.Interfaces;

namespace AloneCoreApp.Data.IRepositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}

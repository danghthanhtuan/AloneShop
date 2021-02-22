using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<List<ProductViewModel>> GetAll();

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        void Save();

        Task<ProductViewModel> GetByIdAsync(int id);

        Task<PagedResult<ProductViewModel>> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);

        Task<List<ProductQuantityViewModel>> GetQuantities(int productId);
    }
}

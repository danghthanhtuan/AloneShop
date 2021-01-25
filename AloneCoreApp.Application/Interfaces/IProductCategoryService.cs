using AloneCoreApp.Application.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Interfaces
{
    public interface IProductCategoryService
    {
        ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm);

        void Update(ProductCategoryViewModel productCategoryVm);

        void Delete(int id);

        Task<List<ProductCategoryViewModel>> GetAll();

        List<ProductCategoryViewModel> GetAll(string keyword);

        List<ProductCategoryViewModel> GetByParentId(int parentId);

        Task<ProductCategoryViewModel> GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);

        void ReOrder(int sourceId, int targetId);

        List<ProductCategoryViewModel> GetHomeCategories(int top);

        void Save();
    }
}

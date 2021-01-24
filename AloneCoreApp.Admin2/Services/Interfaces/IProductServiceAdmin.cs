using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Request;
using AloneCoreApp.Utilities.ResultJson;
using System.Collections.Generic;

namespace AloneCoreApp.Admin2.Services.Interfaces
{
    public interface IProductServiceAdmin
    {
        PagingResult<ProductViewModel> GetAllPaging(ProductPagingRequest productVm);

        ProductViewModel GetProductDetail(int productId);
    }
}

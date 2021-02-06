using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Utilities.Common;
using AloneCoreApp.Utilities.Constants;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Request;
using AloneCoreApp.Utilities.ResultJson;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using AloneCoreApp.Admin2;
using System.Collections.Generic;

namespace AloneCoreApp.Admin2.Services.Implementation
{
    public class ProductServiceAdmin : IProductServiceAdmin
    {
        private readonly IConfiguration _config;
        public ProductServiceAdmin(IConfiguration configuration)
        {
            _config = configuration;
        }

        public PagingResult<ProductViewModel> GetAllPaging(ProductPagingRequest productVm)
        {
            var url = _config["ApiUrl"];
            var param = _config["ApiGetProductPaging"];
            var dataResult = ApiRequest.Post(url, param, productVm, CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<PagingResult<ProductViewModel>>(data.Result);
            }

            return null;
        }

        public List<ProductCategoryViewModel> GetAllProductCategory()
        {
            var dataResult = ApiRequest.Get(_config[Constants.API_URL],
                                _config[Constants.API_GET_PRODUCT_CATEGORY_ALL],
                                CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<List<ProductCategoryViewModel>>(data.Result);
            }

            return null;
        }

        public ProductViewModel GetProductDetail(int productId)
        {
            var param = _config[Constants.API_GET_PRODUCT_DETAIL] + "?productId=" + productId;
            var dataResult = ApiRequest.Get(_config[Constants.API_URL],
                                param,
                                CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<ProductViewModel>(data.Result);
            }

            return null;
        }

        public ProductViewModel AddProduct(ProductViewModel product)
        {
            var dataResult = ApiRequest.Post(_config[Constants.API_URL],
                                _config[Constants.API_ADD_PRODUCT],
                                product,
                                CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<ProductViewModel>(data.Result);
            }

            return null;
        }

        #region UPDATE

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ProductViewModel UpdateProduct(ProductViewModel product)
        {
            var dataResult = ApiRequest.Post(_config[Constants.API_URL],
                                _config[Constants.API_UPDATE_PRODUCT],
                                product,
                                CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<ProductViewModel>(data.Result);
            }

            return null;
        }

        #endregion
    }
}

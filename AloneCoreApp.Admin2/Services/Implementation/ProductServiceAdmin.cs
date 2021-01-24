using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Utilities.Common;
using AloneCoreApp.Utilities.Constants;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Request;
using AloneCoreApp.Utilities.ResultJson;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace AloneCoreApp.Admin2.Services.Implementation
{
    public class ProductServiceAdmin : IProductServiceAdmin
    {
        private readonly IConfiguration _configuration;
        public ProductServiceAdmin(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PagingResult<ProductViewModel> GetAllPaging(ProductPagingRequest productVm)
        {
            var url = _configuration["ApiUrl"];
            var param = _configuration["ApiGetProductPaging"];
            var dataResult = ApiRequest.Post(url, param, productVm, CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<PagingResult<ProductViewModel>>(data.Result);
            }

            return null;
        }

        public ProductViewModel GetProductDetail(int productId)
        {
            var url = _configuration["ApiUrl"];
            var param = _configuration["ApiGetProductDetail"] + "?productId=" + productId;
            var dataResult = ApiRequest.Get(url, param, CommonConstants.ContentTypeJson);
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success)
            {
                return CommonFunction.Format<ProductViewModel>(data.Result);
            }

            return null;
        }
    }
}

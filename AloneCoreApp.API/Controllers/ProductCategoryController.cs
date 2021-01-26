using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Data.Entities;
using AloneCoreApp.Utilities.Constants;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AloneCoreApp.API.Controllers
{
    public class ProductCategoryController : ApiBaseController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var productCategorys = await _productCategoryService.GetAll();
            if (productCategorys != null)
            {
                // The reason : the Result has a Product list for each ProductCategory
                // If you need a list of Products, remove the line below
                productCategorys.ForEach(x => x.Products = new List<ProductViewModel>());

                return new OkObjectResult(new ApiOkResponse(productCategorys));
            }
                
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        [HttpGet]
        [Route("find-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            var products = await _productCategoryService.GetById(id);
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }
    }
}

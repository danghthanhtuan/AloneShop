using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloneCoreApp.Application.Interfaces;
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
        public IActionResult GetAll()
        {
            var productCategorys = _productCategoryService.GetAll();
            if (productCategorys != null)
                return new OkObjectResult(new ApiOkResponse(productCategorys));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));

        }

        [HttpGet]
        [Route("find-by-id")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return new OkObjectResult(new ApiBadResponse("Không nhận được dữ liệu yêu cầu!"));
            }
            var products = _productCategoryService.GetById(id);
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }
    }
}

using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AloneCoreApp.API.Controllers
{
    public class ProductController : ApiBaseController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }

        [HttpPost]
        [Route("paging")]
        public async Task<IActionResult> GetAllPaging(ProductPagingRequest productVm)
        {
            if(!ModelState.IsValid || productVm == null)
            {
                return new OkObjectResult(new ApiBadResponse("Không nhận được dữ liệu yêu cầu!"));
            }
            var products = await _productService.GetAllPaging(productVm.CategoryId, productVm.Keyword, productVm.Page, productVm.PageSize);
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }

        [HttpGet]
        [Route("find-by-id")]
        public IActionResult GetById(int productId)
        {
            if (productId <= 0)
            {
                return new OkObjectResult(new ApiBadResponse("Không nhận được dữ liệu yêu cầu!"));
            }
            var products = _productService.GetById(productId);
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }
    }
}

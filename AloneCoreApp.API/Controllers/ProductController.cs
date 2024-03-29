﻿using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Utilities.Constants;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Helpers;
using AloneCoreApp.Utilities.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloneCoreApp.API.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    public class ProductController : ApiBaseController
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="productCategoryService"></param>
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        #region API GET

        /// <summary>
        /// Get All Data Of Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        /// <summary>
        /// Get All Product Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("category-all")]
        public async Task<IActionResult> GetAllProductCategory()
        {
            var productCategorys = await _productCategoryService.GetAll();
            if (productCategorys != null)
                return new OkObjectResult(new ApiOkResponse(productCategorys));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        /// <summary>
        /// Get All Product Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-quantity")]
        public async Task<IActionResult> GetQuantities(int productId)
        {
            var quantities = await _productService.GetQuantities(productId);
            if (quantities != null)
                return new OkObjectResult(new ApiOkResponse(quantities));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        [HttpPost]
        [Route("paging")]
        public async Task<IActionResult> GetAllPaging(ProductPagingRequest productVm)
        {
            if (!ModelState.IsValid || productVm == null)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            var products = await _productService.GetAllPaging(productVm.CategoryId, productVm.Keyword, productVm.Page, productVm.PageSize);
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        [HttpGet]
        [Route("find-by-id")]
        public async Task<IActionResult> GetById(int productId)
        {
            if (productId <= 0)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            var products = await _productService.GetByIdAsync(productId);
            if (products != null)
                return new OkObjectResult(new ApiOkResponse(products));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        #endregion

        #region API ADD

        [HttpPost]
        [Route("add")]
        public IActionResult Add(ProductViewModel productVm)
        {
            if (!ModelState.IsValid || productVm == null)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            else
            {
                productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (productVm.Id == 0)
                {
                    _productService.Add(productVm);
                }
                _productService.Save();
                return new OkObjectResult(new ApiOkResponse(productVm));
            }
        }

        #endregion

        #region API UPDATE

        [HttpPost]
        [Route("update-images")]
        public IActionResult SaveImages(int productId, string[] images)
        {
            _productService.AddImages(productId, images);
            _productService.Save();
            return new OkObjectResult(new ApiOkResponse(images));
        }

        [HttpPost]
        [Route("get-images")]
        public IActionResult GetImages(int productId)
        {
            var images = _productService.GetImages(productId);
            _productService.Save();
            return new OkObjectResult(new ApiOkResponse(images));
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ProductViewModel productVm)
        {
            if (!ModelState.IsValid || productVm == null)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            else
            {
                productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (productVm.Id != 0)
                {
                    _productService.Update(productVm);
                }
                _productService.Save();
                return new OkObjectResult(new ApiOkResponse(productVm));
            }
        }

        [HttpPost]
        [Route("update-quantity")]
        public IActionResult SaveQuantities(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productService.AddQuantity(productId, quantities);
            _productService.Save();
            return new OkObjectResult(new ApiOkResponse(quantities));
        }

        #endregion

        #region API DELETE

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            _productService.Delete(id);
            _productService.Save();

            return new OkObjectResult(new ApiOkResponse(id));
        }

        #endregion
    }
}

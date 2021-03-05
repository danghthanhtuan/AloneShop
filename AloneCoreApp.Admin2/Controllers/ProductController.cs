using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloneCoreApp.Admin.Services.Interfaces;
using AloneCoreApp.Application.ViewModels.Product;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloneCoreApp.Admin.Controllers
{
    public class ProductController : BaseController
    {

        private readonly IProductServiceAdmin _productServiceAdmin;

        public ProductController(IProductServiceAdmin productServiceAdmin)
        {
            _productServiceAdmin = productServiceAdmin;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult ProductRegister()
        {
            return View();
        }

        #region AJAX API
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetProductPaging([FromBody] ProductPagingRequest productVm)
        {
            // Validate 
            if (!ModelState.IsValid || productVm == null)
            {
                return Ok(new ApiBadResponse("Không nhận được dữ liệu yêu cầu!"));
            }

            var products = _productServiceAdmin.GetAllPaging(productVm);
            if (products != null && products.Results.Count > 0)
            {

                return Ok(new ApiOkResponse(products));
            }
            // Thêm lỗi
            return Ok(new ApiNotFoundResponse(""));
        }

        /// <summary>
        /// Get All Product Category
        /// </summary>
        /// <param name="productVm"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllProductCategory()
        {
            var categorys = _productServiceAdmin.GetAllProductCategory();
            if (categorys != null)
            {
                return Ok(new ApiOkResponse(categorys));
            }
            // Thêm lỗi
            return Ok(new ApiNotFoundResponse(""));
        }

        /// <summary>
        /// Get Detail Of A Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetProductDetail([FromQuery] int productId)
        {
            // Validate 
            if (!ModelState.IsValid || productId <= 0)
            {
                return Ok(new ApiBadResponse("Không nhận được dữ liệu yêu cầu!"));
            }

            var product = _productServiceAdmin.GetProductDetail(productId);
            if (product != null)
            {
                return Ok(new ApiOkResponse(product));
            }
            // Thêm lỗi
            return Ok(new ApiNotFoundResponse(""));
        }

        /// <summary>
        /// Get Detail Of A Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddProduct(ProductViewModel productVm)
        {
            // Validate 
            if (!ModelState.IsValid || productVm == null)
            {
                return Ok(new ApiBadResponse("Không nhận được dữ liệu yêu cầu!"));
            }

            var product = _productServiceAdmin.AddProduct(productVm);
            if (product != null)
            {
                return Ok(new ApiOkResponse(product));
            }
            // Thêm lỗi
            return Ok(new ApiNotFoundResponse(""));
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.Utilities.Dtos;
using AloneCoreApp.Utilities.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AloneCoreApp.Admin2.Controllers
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
        /// Get Detail Of A Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetProductDetail([FromQuery]int productId)
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
        #endregion
    }
}

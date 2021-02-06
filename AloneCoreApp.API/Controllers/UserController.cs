using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Utilities.Constants;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AloneCoreApp.API.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="productCategoryService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region API GET

        /// <summary>
        /// Find User By ID
        /// </summary>
        /// <param name="id">Id Of User</param>
        /// <returns></returns>
        [HttpGet]
        [Route("find-by-id")]
        public async Task<IActionResult> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            var model = await _userService.GetById(id);
            if (model != null)
                return new OkObjectResult(new ApiOkResponse(model));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        /// <summary>
        /// Get List User Paging
        /// </summary>
        /// <param name="keyword">Key word</param>
        /// <param name="page">Page Index</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns></returns>
        [HttpGet]
        [Route("paging")]
        public IActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            if (page <= 0 || pageSize <= 0)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            var users = _userService.GetAllPagingAsync(keyword, page, pageSize);
            if (users != null)
                return new OkObjectResult(new ApiOkResponse(users));
            return new OkObjectResult(new ApiNotFoundResponse(CommonError.DATA_NOT_FOUND));
        }

        #endregion

        #region API ADD

        [HttpPut]
        [Route("add")]
        public async Task<IActionResult> AddEntity(AppUserViewModel userVm)
        {
            if (!ModelState.IsValid || userVm == null)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            else
            {
                await _userService.AddAsync(userVm);

                return new OkObjectResult(new ApiOkResponse(userVm));
            }
        }

        #endregion

        #region API UPDATE

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateEntity(AppUserViewModel userVm)
        {
            if (!ModelState.IsValid || userVm == null)
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            else
            {
                await _userService.UpdateAsync(userVm);

                return new OkObjectResult(new ApiOkResponse(userVm));
            }
        }

        #endregion

        #region API DELETE
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(id))
            {
                return new OkObjectResult(new ApiBadResponse(CommonError.NOT_RECEIVE_REQUEST_DATA));
            }
            else
            {
                await _userService.DeleteAsync(id);

                return new OkObjectResult(new ApiOkResponse(id));
            }
        }
        #endregion
    }
}

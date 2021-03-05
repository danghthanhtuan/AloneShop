using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AloneCoreApp.API.Controllers
{
    public class SizeController : ApiBaseController
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        /// <summary>
        /// Get all Functions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var sizes = await _sizeService.GetAll();
            if (sizes != null)
                return new OkObjectResult(new ApiOkResponse(sizes));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }
    }
}

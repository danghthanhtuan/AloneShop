using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AloneCoreApp.API.Controllers
{
    public class ColorController : ApiBaseController
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        /// <summary>
        /// Get all Functions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var colors = await _colorService.GetAll();
            if (colors != null)
                return new OkObjectResult(new ApiOkResponse(colors));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }
    }
}

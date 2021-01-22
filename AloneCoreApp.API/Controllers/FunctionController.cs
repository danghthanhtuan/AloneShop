using AloneCoreApp.Application.Interfaces;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AloneCoreApp.API.Controllers
{
    public class FunctionController : ApiBaseController
    {
        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        /// <summary>
        /// Get all Functions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> Get()
        {
            var funcs = await _functionService.GetAll();
            if (funcs != null)
                return new OkObjectResult(new ApiOkResponse(funcs));
            return new OkObjectResult(new ApiNotFoundResponse("Không tìm thấy dữ liệu"));
        }
    }
}
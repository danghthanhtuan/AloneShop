using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Utilities.Common;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin2.Services.Implementation
{
    public class FunctionServiceAdmin : IFunctionServiceAdmin
    {
        private readonly IConfiguration _configuration;

        public FunctionServiceAdmin(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<FunctionViewModel> GetAll()
        {
            var url = _configuration["ApiUrl"];
            var param = _configuration["ApiGetFunctionAll"];
            var dataResult = ApiRequest.Get(url, param, "application/json");
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if (data != null && data.Success) return CommonFunction.Format<List<FunctionViewModel>>(data.Result);

            return null;
        }
    }
}

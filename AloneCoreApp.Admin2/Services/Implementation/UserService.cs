using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.API.ViewModels;
using AloneCoreApp.Utilities.Common;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin2.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApiResponse Authenticate(LoginRequest loginRequest)
        {
            var url = _configuration["ApiUrl"];
            var param = "/api/Account/login";
            var dataResult = ApiRequest.Post(url, param, loginRequest, "application/json");
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            return new ApiOkResponse(data);
        }
    }
}

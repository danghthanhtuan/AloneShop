using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.API.ViewModels;
using AloneCoreApp.Utilities.Common;
using AloneCoreApp.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin2.Services.Implementation
{
    public class UserServiceAdmin : IUserServiceAdmin
    {
        private readonly IConfiguration _configuration;

        public UserServiceAdmin(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Account Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public ApiResponse Authenticate(LoginRequest loginRequest)
        {
            var url = _configuration["ApiUrl"];
            var param = _configuration["ApiLoginUrl"];
            var dataResult = ApiRequest.Post(url, param, loginRequest, "application/json");
            var dataResponse = dataResult.Content.ReadAsStringAsync().Result;
            var data = CommonFunction.Format<ApiResponse>(dataResponse);

            if(data != null && data.Success) return data;

            if(data == null)
                return new ApiBadResponse("Không thể đăng nhập");
            else return new ApiBadResponse(data.Messages);
        }
    }
}

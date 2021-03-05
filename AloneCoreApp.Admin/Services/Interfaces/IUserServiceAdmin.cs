using AloneCoreApp.API.ViewModels;
using AloneCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin.Services.Interfaces
{
    public interface IUserServiceAdmin
    {
        ApiResponse Authenticate(LoginRequest request);

        //Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request);

        //Task<ApiResult<bool>> RegisterUser(RegisterRequest request);

        //Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        //Task<ApiResult<UserViewModel>> GetById(Guid id)
    }
}

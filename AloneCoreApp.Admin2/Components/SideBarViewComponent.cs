using AloneCoreApp.Admin.Extensions;
using AloneCoreApp.Admin.Services.Interfaces;
using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly IFunctionServiceAdmin _functionServiceAdmin;

        public SideBarViewComponent(IFunctionServiceAdmin functionServiceAdmin)
        {
            _functionServiceAdmin = functionServiceAdmin;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;

            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                 functions = _functionServiceAdmin.GetAll();
            }
            else
            {
                 functions = new List<FunctionViewModel>();
            }
            return View(functions.OrderBy(x => x.SortOrder).ToList());
        }
    }
}
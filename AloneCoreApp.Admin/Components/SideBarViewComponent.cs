using AloneCoreApp.Admin.Extensions;
using AloneCoreApp.Application.Interfaces;
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
        private readonly IFunctionService _functionService;

        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;

            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }
            else
            {
                functions = new List<FunctionViewModel>();
            }
            return View(functions);
        }
    }
}

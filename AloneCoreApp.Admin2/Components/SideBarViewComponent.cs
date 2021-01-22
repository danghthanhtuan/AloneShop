﻿using AloneCoreApp.Admin2.Extensions;
using AloneCoreApp.Admin2.Services.Interfaces;
using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin2.Components
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
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("roles");
            List<FunctionViewModel> functions;

            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                 functions = _functionServiceAdmin.GetAll();
            }
            else
            {
                // functions = new List<FunctionViewModel>();
            }
            return View();
        }
    }
}
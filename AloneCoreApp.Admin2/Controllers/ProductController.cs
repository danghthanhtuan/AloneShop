﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AloneCoreApp.Admin2.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

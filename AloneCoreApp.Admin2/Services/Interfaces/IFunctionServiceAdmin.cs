using AloneCoreApp.Application.ViewModels.System;
using AloneCoreApp.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloneCoreApp.Admin.Services.Interfaces
{
    public interface IFunctionServiceAdmin
    {
        List<FunctionViewModel> GetAll();
    }
}

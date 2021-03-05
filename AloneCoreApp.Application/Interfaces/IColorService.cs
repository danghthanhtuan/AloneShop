using AloneCoreApp.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Application.Interfaces
{
    public interface IColorService : IDisposable
    {
        Task<List<ColorViewModel>> GetAll();
    }
}

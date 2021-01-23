using AloneCoreApp.Data.Entities;
using AloneCoreApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Data.IRepositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}

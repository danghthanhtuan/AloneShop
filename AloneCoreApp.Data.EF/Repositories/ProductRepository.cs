using AloneCoreApp.Data.Entities;
using AloneCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Data.EF.Repositories
{
    public class ProductRepository : EFRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}

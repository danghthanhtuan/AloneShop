using AloneCoreApp.Data.Entities;
using AloneCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Data.EF.Repositories
{
    public class ProductTagRepository : EFRepository<ProductTag, int>, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}

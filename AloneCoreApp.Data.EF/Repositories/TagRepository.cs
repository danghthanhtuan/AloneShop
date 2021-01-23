using AloneCoreApp.Data.Entities;
using AloneCoreApp.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}

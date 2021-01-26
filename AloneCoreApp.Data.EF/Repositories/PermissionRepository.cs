using AloneCoreApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Data.EF.Repositories
{
    public class PermissionRepository : EFRepository<Permission, int>
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {       
        void Commit();
    }
}

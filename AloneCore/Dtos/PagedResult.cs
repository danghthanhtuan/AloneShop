using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AloneCoreApp.Utilities.Dtos
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public PagedResult()
        {
            Results = new List<T>();
        }

        public List<T> Results { get; set; }
    }
}

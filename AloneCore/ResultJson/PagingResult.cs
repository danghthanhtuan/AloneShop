using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Utilities.ResultJson
{
    public class PagingResult<T> 
    {
        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
        public List<T> Results { get; set; }

        public int PageSize { get; set; }

        public int RowCount { get; set; }
    }
}

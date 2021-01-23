using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloneCoreApp.API.ViewModels
{
    public class ProductPagingViewModel
    {
        public int? CategoryId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }
    }
}

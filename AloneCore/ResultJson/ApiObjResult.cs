using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Utilities.ResultJson
{
    public class ApiObjResult<T>
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public List<T> Results { get; set; }
        public string Messages { get; set; }
    }

    public class ApiObjSingleResult<T>
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public T Results { get; set; }
        public string Messages { get; set; }
    }
}

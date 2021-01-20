using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AloneCoreApp.Utilities.Common
{
    public static class CommonFunction
    {
        public static T Format<T>(Object obj) => JsonConvert.DeserializeObject<T>(obj.ToString());
    }
}

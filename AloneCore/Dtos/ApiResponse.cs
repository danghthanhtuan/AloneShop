using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AloneCoreApp.Utilities.Dtos
{
    public class ApiResponse
    {
        public int code { get; set; }
        public bool success { get; set; }
        public object result { get; set; }
        public string messages { get; set; }
    }

    public class ApiNotFoundResponse : ApiResponse
    {
        public ApiNotFoundResponse(string message)
        {
            code = (int)HttpStatusCode.NotFound;
            success = false;
            result = null;
            messages = message;
        }
    }

    public class ApiBadResponse : ApiResponse
    {
        public ApiBadResponse(string message)
        {
            code = (int)HttpStatusCode.BadRequest;
            success = false;
            result = null;
            messages = message;
        }
    }

    public class ApiOkResponse : ApiResponse
    {
        public ApiOkResponse(object data)
        {
            code = (int)HttpStatusCode.OK;
            success = true;
            result = data;
            messages = string.Empty;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Likvido.Invoice.ApiClient
{
    public class ApiResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }
    }
}

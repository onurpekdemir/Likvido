using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.ApiClient.Response
{
    /// <summary>
    /// Incoming data from API
    /// </summary>
    public class ApiResponse<T>
    {
        public List<T> Data { get; set; }
        public List<ApiError> Errors{ get; set; }

    }
}

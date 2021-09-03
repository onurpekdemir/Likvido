using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.ApiClient.Errors
{
    /// <summary>
    /// Thrown if the API has any errors (500)
    /// </summary>
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string Details { get; set; }

        public ApiException(int statusCode, string details = null)
        {
            StatusCode = statusCode;
            Details = details;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.ApiClient.Response
{
    /// <summary>
    /// Represent API error if any
    /// </summary>
    public class ApiError
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }
}

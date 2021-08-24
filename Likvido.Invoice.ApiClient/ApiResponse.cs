using System;
using System.Collections.Generic;
using System.Text;

namespace Likvido.Invoice.ApiClient
{
    public class ApiResponse
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }

    public class ApiResponseList
    {
        public List<ApiResponse> Errors { get; set; }
    }
}

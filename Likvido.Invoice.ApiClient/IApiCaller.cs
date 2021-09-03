using Likvido.Invoice.ApiClient.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Likvido.Invoice.ApiClient
{
    public interface IApiCaller
    {
        Task<ApiResponse<T>> GetAsync<T>(string path);
        Task<ApiResponse<T>> Post<T>(string path, object data);
    }
}

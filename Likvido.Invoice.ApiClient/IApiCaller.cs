using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Likvido.Invoice.ApiClient
{
    public interface IApiCaller
    {
        Task<ApiResult> GetAsync<T>(string path);
        Task<ApiResult> Post(string path, object data);
    }
}

using Likvido.Invoice.ApiClient.Errors;
using Likvido.Invoice.ApiClient.Response;
using Likvido.Invoice.ApiClient.Settings;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Likvido.Invoice.ApiClient
{
    public class ApiCaller : IApiCaller
    {
        private readonly IOptions<ApiSettings> _options;

        public ApiCaller(IOptions<ApiSettings> options)
        {
            _options = options;
        }

        public async Task<ApiResponse<T>> GetAsync<T>(string path)
        {
            using (var httpClient = new HttpClient())
            {
                SetHeaders(httpClient);

                using (var response = await httpClient.GetAsync(_options.Value.Uri + path))
                {
                    CheckApiInternalError(response);

                    string apiResponseString = await response.Content.ReadAsStringAsync();

                    var apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<T>>(apiResponseString);

                    return apiResponse;
                }
            }
        }

        public async Task<ApiResponse<T>> Post<T>(string path, object data)
        {
            using (var httpClient = new HttpClient())
            {
                SetHeaders(httpClient);

                string contentString = JsonSerializer.Serialize(data);
                using (var response = await httpClient.PostAsync(_options.Value.Uri + path,
                    new StringContent(contentString, Encoding.UTF8, "application/json")))
                {
                    CheckApiInternalError(response);

                    if (!response.IsSuccessStatusCode)
                    {
                        string apiResponseString = await response.Content.ReadAsStringAsync();
                        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponse<T>>(apiResponseString);
                    }

                    return new ApiResponse<T> { };
                }
            }
        }
        private void CheckApiInternalError(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new ApiException((int)response.StatusCode, "Error occured while fetching/sending data from the API");
            }
        }

        private void SetHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("X-ApiKey", _options.Value.Key);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
        }
    }
}

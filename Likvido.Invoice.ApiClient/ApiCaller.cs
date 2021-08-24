using Microsoft.Extensions.Options;
using System;
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

        public async Task<ApiResult> GetAsync<T>(string path)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-ApiKey", _options.Value.Key);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                using (var response = await httpClient.GetAsync(_options.Value.Uri + path))
                {
                    string apiResponseString = await response.Content.ReadAsStringAsync();
                    ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(apiResponseString);

                    return new ApiResult
                    {
                        Result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(apiResponseString),
                        HttpStatusCode = response.StatusCode,
                        Message = apiResponse.Title
                    };
                }
            }
        }

        public async Task<ApiResult> Post(string path, object data)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-ApiKey", _options.Value.Key);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

                string contentString = JsonSerializer.Serialize(data);
                using (var response = await httpClient.PostAsync(_options.Value.Uri + path,
                    new StringContent(contentString, Encoding.UTF8, "application/json")))
                {
                    string apiResponseString = await response.Content.ReadAsStringAsync();
                    ApiResponseList apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResponseList>(apiResponseString);

                    return new ApiResult
                    {
                        // Result = JsonConvert.DeserializeObject<T>(apiResponse),
                        HttpStatusCode = response.StatusCode,
                        Message = apiResponse != null ? string.Join(',', apiResponse.Errors.Select(s => s.Title)) : ""
                    };
                }
            }
        }
    }
}

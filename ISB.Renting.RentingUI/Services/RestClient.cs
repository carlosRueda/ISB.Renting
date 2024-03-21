using Newtonsoft.Json;
using System.Text;

namespace ISB.Renting.RentingUI.Services;

public class RestClient : HttpClient
{
    private readonly HttpClient _httpClient;

    public RestClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.Timeout = TimeSpan.FromSeconds(10);
    }

    public HttpResponseMessage Get(string url) =>
        ExecuteHttpRequest(null, HttpMethod.Get, url);

    public HttpResponseMessage Delete(string url) =>
        ExecuteHttpRequest(null, HttpMethod.Delete, url);

    public HttpResponseMessage Post(object objectToSend, string url) =>
        ExecuteHttpRequest(objectToSend, HttpMethod.Post, url);

    public HttpResponseMessage Put(object objectToSend, string url) =>
        ExecuteHttpRequest(objectToSend, HttpMethod.Put, url);

    public async Task<TApiResponse> GetResponseAsync<TApiResponse>(HttpResponseMessage responseMessage)
    {
        var jsonResult = await responseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TApiResponse>(jsonResult);
    }

    #region private

    private HttpResponseMessage ExecuteHttpRequest(object? value, HttpMethod method, string url)
    {
        var request = CreateHttpRequest(value, method, url);
        return _httpClient.SendAsync(request, cancellationToken: default).GetAwaiter().GetResult();
    }

    private HttpRequestMessage CreateHttpRequest(object? value, HttpMethod method, string url)
    {
        var request = new HttpRequestMessage(method, url);

        if (value != null)
            request.Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");

        return request;
    }

    #endregion
}

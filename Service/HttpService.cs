using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public sealed class HttpService : IDisposable
{
    private static readonly Lazy<HttpService> instance = new(() => new HttpService());
    private readonly HttpClient client;

    private HttpService()
    {
        client = new HttpClient();
    }

    public static HttpService Instance => instance.Value;

    public async Task<string> GET(string uri, Dictionary<string, string>? parameters = null)
    {
        try
        {
            var uriBuilder = new UriBuilder(uri);
            if (parameters != null)
            {
                // Aggiunta del TOKEN di OpenWeather
                parameters.Add("appid", Config.API_TOKEN);
                parameters.Add("lang", "it");

                var query = new FormUrlEncodedContent(parameters).ReadAsStringAsync().Result;
                uriBuilder.Query = query;

                //Console.WriteLine($"{query}");
            }

            // Make the request
            Console.WriteLine(uriBuilder.ToString());
            HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            return $"Error x: {ex.Message}";
        }
    }

    public void Dispose()
    {
        client.Dispose();
    }
}

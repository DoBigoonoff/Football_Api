using System;
using GetNewsModels;
using Newtonsoft.Json;

namespace Clients;

public class GetNewsClient
{
    public async Task<GetNews> GetNewsAsync(string Request)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://newsdata2.p.rapidapi.com/news?language=en&q={Request}"), // %20
            Headers =
    {
        { "X-RapidAPI-Key", "8955d23492msh82a78f9451adc20p1c7889jsn06e2be356e7b" },
        { "X-RapidAPI-Host", "newsdata2.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetNews>(content);
            return result;
        }
    }
}

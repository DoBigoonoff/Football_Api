using System;
using GetLiveMatchesModels;
using Newtonsoft.Json;
namespace Clients;

public class GetLiveMatchesClient
{
    public async Task<GetLiveMatches> GetLiveMatchesAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://sportscore1.p.rapidapi.com/sports/1/events/live?page=1"),
            Headers =
    {
        { "X-RapidAPI-Key", "8955d23492msh82a78f9451adc20p1c7889jsn06e2be356e7b" },
        { "X-RapidAPI-Host", "sportscore1.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetLiveMatches>(content);
            return result;
        }
    }
}

using System;
using GetLeagueIdModels;
using Newtonsoft.Json;
namespace Clients;

public class GetLeagueIdClient
{
    public async Task<GetLeagueId> GetLeagueIdAsync(string Country)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://v3.football.api-sports.io/leagues?country={Country}"),
            Headers = {
    { "X-RapidAPI-Key", "0b9d34c0a48288ff7e5d61399e23b613" },
    { "X-RapidAPI-Host", "v3.football.api-sports.io" },},
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetLeagueId>(content);
            return result;
        }
    }
}

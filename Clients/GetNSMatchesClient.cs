using System;
using GetNSMatchesModels;
using Newtonsoft.Json;
namespace Clients;

public class GetNSMatchesClient
{
    public async Task<GetNSMatches> GetNSMatchesAsync(string Team, string Player)
    {
        GetPlayerClient Id = new GetPlayerClient();
        var Idresult = Id.GetPlayerAsync(Team, Player).Result;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://v3.football.api-sports.io/fixtures?league={Idresult.Response[0].Statistics[0].League.Id}&season=2022&status=NS"),
            Headers = {
    { "X-RapidAPI-Key", "0b9d34c0a48288ff7e5d61399e23b613" },
    { "X-RapidAPI-Host", "v3.football.api-sports.io" },},
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetNSMatches>(content);
            return result;
        }
    }
}

using System;
using GetTeamModels;
using Newtonsoft.Json;

namespace Clients;

public class GetTeamClient
{
    public async Task<GetTeam> GetTeamAsync(string TeamName)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://v3.football.api-sports.io/teams?name={TeamName}"),
            Headers = {
{ "X-RapidAPI-Key", "0b9d34c0a48288ff7e5d61399e23b613" },
{ "X-RapidAPI-Host", "v3.football.api-sports.io" },},
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetTeam>(content);
            return result;
        }
    }
}


using System;
using GetPlayerModels;
using Newtonsoft.Json;
namespace Clients;

public class GetPlayerClient
{
    public async Task<GetPlayer> GetPlayerAsync(string FootballClub, string PlayerName)
    {
        GetTeamClient Id = new GetTeamClient();
        var Idresult = Id.GetTeamAsync(FootballClub).Result;
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://v3.football.api-sports.io/players?team={Idresult.Response[0].Team.Id}&search={PlayerName}&season=2022"),
            Headers = {
    { "X-RapidAPI-Key", "0b9d34c0a48288ff7e5d61399e23b613" },
    { "X-RapidAPI-Host", "v3.football.api-sports.io" },},
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetPlayer>(content);
            return result;
        }
    }
}


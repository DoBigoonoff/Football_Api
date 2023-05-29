using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using GetPlayerModels;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerPost : ControllerBase
    {
        private readonly ILogger<PlayerPost> _logger;
        public PlayerPost(ILogger<PlayerPost> logger)
        {
            _logger = logger;
        }
        [HttpPost(Name = "PlayerPost")]
        public async void Player(string FootballClub, string PlayerName)
        {
            string Connect = "Host=localhost;Username=postgres;Password=989545;Database=postgres";
            NpgsqlConnection con = new NpgsqlConnection(Connect);
            GetPlayerClient client = new GetPlayerClient();
            ResponsePlayer player = client.GetPlayerAsync(FootballClub, PlayerName).Result.Response[0];
            var sql = "insert into public.\"Players\"(\"id\", \"firstname\", \"lastname\", \"age\", \"height\", \"weight\", \"position\", \"rating\", \"clubname\")"
                + $"values (@id, @firstname, @lastname, @age, @height, @weight, @position, @rating, @clubname)";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.Parameters.AddWithValue("id", player.Player.Id);
            comm.Parameters.AddWithValue("firstname", player.Player.Firstname);
            comm.Parameters.AddWithValue("lastname", player.Player.Lastname);
            comm.Parameters.AddWithValue("age", player.Player.Age);
            comm.Parameters.AddWithValue("height", player.Player.Height);
            comm.Parameters.AddWithValue("weight", player.Player.Weight);
            comm.Parameters.AddWithValue("position", player.Statistics[0].Games.Position);
            comm.Parameters.AddWithValue("rating", player.Statistics[0].Games.Rating);
            comm.Parameters.AddWithValue("clubname", player.Statistics[0].Team.Name);
            await con.OpenAsync();
            await comm.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}


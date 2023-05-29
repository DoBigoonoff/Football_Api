using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using SelectPlayers;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerGet : ControllerBase
    {
        private readonly ILogger<PlayerGet> _logger;
        public PlayerGet(ILogger<PlayerGet> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "PlayerGet")]
        public async Task<List<Players>> SelectPlayer()
        {
            string Connect = "Host=localhost;Username=postgres;Password=989545;Database=postgres";
            NpgsqlConnection con = new NpgsqlConnection(Connect);
            List<Players> players = new List<Players>();
            await con.OpenAsync();
            var sql = "select * from public.\"Players\"";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            NpgsqlDataReader reader = await comm.ExecuteReaderAsync();
            List<int> id = new List<int>();
            while(await reader.ReadAsync())
            {
                if (id.Contains(reader.GetInt32(0)))
                continue;
                players.Add(new Players { id = reader.GetInt32(0), firstname = reader.GetString(1), lastname = reader.GetString(2), age = reader.GetInt32(3), height = reader.GetString(4), weight = reader.GetString(5), position = reader.GetString(6), rating = reader.GetString(7), clubname = reader.GetString(8)});
                id.Add(reader.GetInt32(0));
            }
            await con.CloseAsync();
            return players;
        }
    }
}

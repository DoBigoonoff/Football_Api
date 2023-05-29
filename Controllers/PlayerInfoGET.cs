using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetPlayerModels;
using Clients;


namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerInfo : ControllerBase
    {
        private readonly ILogger<PlayerInfo> _logger;
        public PlayerInfo(ILogger<PlayerInfo> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "PlayerInfo")]
        public ResponsePlayer Player(string FootballClub, string PlayerName)
        {
            GetPlayerClient client = new GetPlayerClient();
            return client.GetPlayerAsync(FootballClub, PlayerName).Result.Response[0];
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using GetTeamModels;
using Microsoft.AspNetCore.Mvc;

namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamInfo : ControllerBase
    {
        private readonly ILogger<TeamInfo> _logger;
        public TeamInfo(ILogger<TeamInfo> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public GetTeam Team(string Club)
        {
            GetTeamClient client = new GetTeamClient();
            return client.GetTeamAsync(Club).Result;
        }
    }
}


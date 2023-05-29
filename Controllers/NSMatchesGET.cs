using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using GetNSMatchesModels;
using Microsoft.AspNetCore.Mvc;

namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NSMatches : ControllerBase
    {
        private readonly ILogger<NSMatches> _logger;
        public NSMatches(ILogger<NSMatches> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "NSMatches")]
        public GetNSMatches Matches(string Team, string Player)
        {
            GetNSMatchesClient client = new GetNSMatchesClient();
            return client.GetNSMatchesAsync(Team, Player).Result;
        }
    }
}


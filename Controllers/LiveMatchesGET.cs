using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GetLiveMatchesModels;
using Clients;


namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveMatches : ControllerBase
    {
        private readonly ILogger<PlayerInfo> _logger;
        public LiveMatches(ILogger<PlayerInfo> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "LiveMatches")]
        public GetLiveMatches Live()
        {
            GetLiveMatchesClient client = new GetLiveMatchesClient();
            return client.GetLiveMatchesAsync().Result;
        }
    }
}

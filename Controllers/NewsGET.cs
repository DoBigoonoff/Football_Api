using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using GetNewsModels;
using Microsoft.AspNetCore.Mvc;

namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class News : ControllerBase
    {
        private readonly ILogger<News> _logger;
        public News(ILogger<News> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public GetNews NewsRequest(string Request)
        {
            GetNewsClient client = new GetNewsClient();
            return client.GetNewsAsync(Request).Result;
        }
    }
}

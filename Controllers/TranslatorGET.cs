using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clients;
using Microsoft.AspNetCore.Mvc;
using TranslatorModels;

namespace Football_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Translate : ControllerBase
    {
        private readonly ILogger<Translate> _logger;
        public Translate(ILogger<Translate> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public Translator TranslateText(string text, string source, string target)
        {
            TranslatorClient client = new TranslatorClient();
            return client.TranslateAsync(text, source, target).Result;
        }
    }
}
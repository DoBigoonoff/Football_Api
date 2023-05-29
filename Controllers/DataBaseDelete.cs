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
    public class Delete : ControllerBase
    {
        private readonly ILogger<Delete> _logger;
        public Delete(ILogger<Delete> logger)
        {
            _logger = logger;
        }
        [HttpDelete(Name = "Delete")]
        public void DeleteAll()
        {
            string Connect = "Host=localhost;Username=postgres;Password=989545;Database=postgres";
            NpgsqlConnection con = new NpgsqlConnection(Connect);
            con.Open();
            var sql = "delete from public.\"Players\"";
            NpgsqlCommand comm = new NpgsqlCommand(sql, con);
            comm.ExecuteReader();
            con.Close();
        }
    }
}

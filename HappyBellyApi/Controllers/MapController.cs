using HappyBellyApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HappyBellyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMap _map = null;

        public MapController(IMap map)
        {
            _map = map;
        }

        // GET: api/<MapController>
        [HttpGet]
        public string Get()
        {
            return $"Maps provider: {_map.DataSourceName}";
        }

        // GET api/<MapController>/Mikolaja%20Reja
        [HttpGet("{query}")]
        public string Get(string query)
        {
            return _map.GetCoordinates(query).ToString();
        }
    }
}

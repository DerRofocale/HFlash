using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HFlashServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public List<Root> Get()
        {
            return Startup._json;
        }

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        public bool Get(int id)
        {
            return Startup._json.Find(x => x.FlatNumber == id).IsEnable;
        }

        // POST api/<FlatsController>
        [HttpPost]
        public List<Root> Post([FromBody] List<Root> value)
        {
            Startup._json = value;
            return value;
        }
    }
}

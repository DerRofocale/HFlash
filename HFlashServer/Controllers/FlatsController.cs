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
        /// <summary>
        /// Получение статусов всех помещений
        /// </summary>
        /// <returns>Абобка</returns>
        [HttpGet]
        public List<Root> Get()
        {
            return Startup._json;
        }

        // GET api/<FlatsController>/5
        /// <summary>
        /// Получение статуса по номеру помещения
        /// </summary>
        /// <param name="id">Номер помещения</param>
        /// <returns>Абибка</returns>
        [HttpGet("{id}")]
        public bool Get(int id)
        {
            return Startup._json.Find(x => x.FlatNumber == id).IsEnable;
        }

        // POST api/<FlatsController>
        /// <summary>
        /// Установка статусов для всех помещений
        /// </summary>
        /// <param name="value">Лист с указанем помещения и статуса</param>
        /// <returns>Абебка</returns>
        [HttpPost]
        public List<Root> Post([FromBody] List<Root> value)
        {
            Startup._json = value;
            return value;
        }
    }
}

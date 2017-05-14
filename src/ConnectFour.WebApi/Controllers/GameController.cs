using System.Collections.Generic;
using ConnectFour.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectFour.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGameRepo _repo;

        public GameController(IGameRepo repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

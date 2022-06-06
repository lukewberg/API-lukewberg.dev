using API_lukewberg.dev.Models;
using API_lukewberg.dev.Utils;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_lukewberg.dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private MongoUtils<Page> mongoUtils { get; set; }
        public PageController(MongoClient mongoClient)
        {
            mongoUtils = new MongoUtils<Page>(mongoClient);
        }
        // GET: api/<PageController>
        [HttpGet]
        public IEnumerable<Page> Get(string route)
        {
            var collection = mongoUtils.GetCollection<Page>("pages");
            var filter = Builders<Page>.Filter.Where(x => x.Route.Equals(route));
            var page = mongoUtils.GetDocument(collection, filter).ToList();
            return page;
        }

        // POST api/<PageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

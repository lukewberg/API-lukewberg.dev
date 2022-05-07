using API_lukewberg.dev.Models;
using API_lukewberg.dev.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace API_lukewberg.dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase {

        private MongoService _mongoService;
        public ArticleController(MongoService mongoService)
        {
            _mongoService = mongoService;
        }

        [HttpGet]
        public IEnumerable<Article> Get()
        {
            var collection = _mongoService.Database.GetCollection<Article>("articles");
            List<Article> result = collection.Find(new BsonDocument()).SortByDescending(article => article.TimeStamp).Limit(5).ToList();

            return result;
        }
    }
}

using API_lukewberg.dev.Models;
using API_lukewberg.dev.Utils;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Tag = API_lukewberg.dev.Models.Tag;

namespace API_lukewberg.dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase {

        private MongoUtils<Article> mongoUtils { get; set; }

        public ArticleController(MongoClient mongoClient)
        {
            mongoUtils = new MongoUtils<Article>(mongoClient);
        }

        [HttpGet]
        public IEnumerable<Article> Get(int page, int limit)
        {
            var collection = mongoUtils.Database.GetCollection<Article>("articles");
            List<Article> result = mongoUtils.GetPaginatedDocuments(collection, page, limit);
            var tagCollection = mongoUtils.GetCollection<Tag>("tags");

            result.ForEach(x =>
            {
                x.Tags = mongoUtils.GetDocuemntsFromList(tagCollection, x.GetTagRefs());
            });

            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(Article article)
        {
            article.TimeStamp = DateTime.Now;
            var collection = mongoUtils.GetCollection<Article>("articles");
            await mongoUtils.CreateDocument(collection, article);

            return CreatedAtAction(nameof(Post), new { article._id }, article);
        }
    }
}

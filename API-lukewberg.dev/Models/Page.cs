using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_lukewberg.dev.Models
{
    public class Page: Document
    {
        [BsonElement("route")]
        public string Route { get; set; }

        [BsonElement("name")]
        public String Name { get; set; }

        public List<Document> Components { get; set; }

        [BsonElement("components")]
        private List<ObjectId> _components { get; set; }
    }
}

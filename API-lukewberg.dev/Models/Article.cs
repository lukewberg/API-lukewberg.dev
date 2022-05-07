using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_lukewberg.dev.Models
{
    public class Article
    {
        [BsonId]
        public ObjectId ArticleId { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("body")]
        public string Body { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("timestamp")]
        public DateTime TimeStamp { get; set; }

    }
}

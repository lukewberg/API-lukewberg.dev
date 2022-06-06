using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_lukewberg.dev.Models
{
    public class Article : Document
    {

        [BsonElement("title")]
        public string Title { get; set; } = null!;

        [BsonElement("body")]
        public string Body { get; set; } = null!;

        [BsonIgnore]
        public List<Tag>? Tags { get; set; } = null!;

        [BsonElement("tags")]
        private List<ObjectId>? _tags { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("timestamp")]
        public DateTime? TimeStamp { get; set; } = null!;

        public List<ObjectId> GetTagRefs()
        {
            return _tags;
        }

    }
}

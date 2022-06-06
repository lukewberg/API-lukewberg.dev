using System;
using MongoDB.Bson.Serialization.Attributes;

namespace API_lukewberg.dev.Models
{
	public class Component: Document
	{
        [BsonElement("componentName")]
		public string ComponentName { get; set; }

        [BsonElement("props")]
		public dynamic Props { get; set; }
	}
}


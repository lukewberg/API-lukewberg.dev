using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_lukewberg.dev.Models
{
	public class Tag : Document
	{
		[BsonElement("name")]
		public string Name { get; set; }
	}
}

